using AutoMapper;
using sutoss.Domain.Services.Domain.Filters;
using sutoss.Domain.Services.Domain.Repositories.Interfaces;
using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using sutoss.Domain.Services.Domain.Services.Base;
using sutoss.Domain.Services.Domain.Services.Interfaces;
using sutoss.Domain.Services.Exceptions;
using sutoss.Domain.Services.Helpers;
using sutoss.Domain.Services.Repositories;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace sutoss.Domain.Services.Domain.Services
{
    public class pretamosService : BaseService, IpretamosService
    {
        private readonly IprestamoRepository _prestamoRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public pretamosService(
            IprestamoRepository prestamoRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _prestamoRepository = prestamoRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<prestamoResponse> Create(prestamoRequest newprestamo, string externalUserId)
        {
            var transaction = _prestamoRepository.BeginTransaction();
            try
            {

                prestamo entity= _mapper.Map<prestamo>(newprestamo);
                var addedprestamo = await _prestamoRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<prestamoResponse>(addedprestamo);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id, string externalUserId)
        {
            var transaction = _prestamoRepository.BeginTransaction();
            try
            {
                var result = (await _prestamoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "prestamo not found");
                }
                await _prestamoRepository.Delete(result.prestamoId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<prestamoResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<prestamo> items = await _prestamoRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<prestamoResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<prestamoResponse> GetById(int id)
        {
            try
            {
                var result = (await _prestamoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "prestamo not found");
                }
                return _mapper.Map<prestamoResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<prestamoResponse> Update(prestamoRequest updatedprestamo, string externalUserId)
        {
            var transaction = _prestamoRepository.BeginTransaction();
            try
            {

                var mappedprestamo = (await _prestamoRepository.Get(updatedprestamo.prestamoId)).FirstOrDefault();
		        var result = await _prestamoRepository.Update(mappedprestamo);
                var mappedResponse = _mapper.Map<prestamoResponse>(result);
                transaction.Commit();
                return mappedResponse;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

    }
}
