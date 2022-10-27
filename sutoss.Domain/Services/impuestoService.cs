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
    public class impuestosService : BaseService, IimpuestosService
    {
        private readonly IimpuestoRepository _impuestoRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public impuestosService(
            IimpuestoRepository impuestoRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _impuestoRepository = impuestoRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<impuestoResponse> Create(impuestoRequest newimpuesto, string externalUserId)
        {
            var transaction = _impuestoRepository.BeginTransaction();
            try
            {

                impuesto entity= _mapper.Map<impuesto>(newimpuesto);
                var addedimpuesto = await _impuestoRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<impuestoResponse>(addedimpuesto);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id, string externalUserId)
        {
            var transaction = _impuestoRepository.BeginTransaction();
            try
            {
                var result = (await _impuestoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "impuesto not found");
                }
                await _impuestoRepository.Delete(result.impuestoId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<impuestoResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<impuesto> items = await _impuestoRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<impuestoResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<impuestoResponse> GetById(int id)
        {
            try
            {
                var result = (await _impuestoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "impuesto not found");
                }
                return _mapper.Map<impuestoResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<impuestoResponse> Update(impuestoRequest updatedimpuesto, string externalUserId)
        {
            var transaction = _impuestoRepository.BeginTransaction();
            try
            {

                var mappedimpuesto = (await _impuestoRepository.Get(updatedimpuesto.impuestoId)).FirstOrDefault();
		        var result = await _impuestoRepository.Update(mappedimpuesto);
                var mappedResponse = _mapper.Map<impuestoResponse>(result);
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
