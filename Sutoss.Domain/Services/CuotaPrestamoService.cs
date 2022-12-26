using AutoMapper;
using Sutoss.Domain.Services.Domain.Filters;
using Sutoss.Domain.Services.Domain.Repositories.Interfaces;
using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using Sutoss.Domain.Services.Domain.Services.Base;
using Sutoss.Domain.Services.Domain.Services.Interfaces;
using Sutoss.Domain.Services.Exceptions;
using Sutoss.Domain.Services.Helpers;
using Sutoss.Domain.Services.Repositories;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace Sutoss.Domain.Services.Domain.Services
{
    public class CuotaPrestamosService : BaseService, ICuotaPrestamosService
    {
        private readonly ICuotaPrestamoRepository _CuotaPrestamoRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public CuotaPrestamosService(
            ICuotaPrestamoRepository CuotaPrestamoRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _CuotaPrestamoRepository = CuotaPrestamoRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<CuotaPrestamoResponse> Create(CuotaPrestamoRequest newCuotaPrestamo )
        {
            var transaction = _CuotaPrestamoRepository.BeginTransaction();
            try
            {

                CuotaPrestamo entity= _mapper.Map<CuotaPrestamo>(newCuotaPrestamo);
                var addedCuotaPrestamo = await _CuotaPrestamoRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<CuotaPrestamoResponse>(addedCuotaPrestamo);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {
            var transaction = _CuotaPrestamoRepository.BeginTransaction();
            try
            {
                var result = (await _CuotaPrestamoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "CuotaPrestamo not found");
                }
                await _CuotaPrestamoRepository.Delete(result.IdCuotaPrestamo);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<CuotaPrestamoResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<CuotaPrestamo> items = await _CuotaPrestamoRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<CuotaPrestamoResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CuotaPrestamoResponse> GetById(int id)
        {
            try
            {
                var result = (await _CuotaPrestamoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "CuotaPrestamo not found");
                }
                return _mapper.Map<CuotaPrestamoResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CuotaPrestamoResponse> Update(CuotaPrestamoRequest updatedCuotaPrestamo )
        {
            var transaction = _CuotaPrestamoRepository.BeginTransaction();
            try
            {

                var mappedCuotaPrestamo = (await _CuotaPrestamoRepository.Get(updatedCuotaPrestamo.IdCuotaPrestamo)).FirstOrDefault();
		        var result = await _CuotaPrestamoRepository.Update(mappedCuotaPrestamo);
                var mappedResponse = _mapper.Map<CuotaPrestamoResponse>(result);
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
