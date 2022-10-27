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
    public class ordenes_pagoService : BaseService, Iordenes_pagoService
    {
        private readonly Iorden_pagoRepository _orden_pagoRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public ordenes_pagoService(
            Iorden_pagoRepository orden_pagoRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _orden_pagoRepository = orden_pagoRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<orden_pagoResponse> Create(orden_pagoRequest neworden_pago, string externalUserId)
        {
            var transaction = _orden_pagoRepository.BeginTransaction();
            try
            {

                orden_pago entity= _mapper.Map<orden_pago>(neworden_pago);
                var addedorden_pago = await _orden_pagoRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<orden_pagoResponse>(addedorden_pago);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id, string externalUserId)
        {
            var transaction = _orden_pagoRepository.BeginTransaction();
            try
            {
                var result = (await _orden_pagoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "orden_pago not found");
                }
                await _orden_pagoRepository.Delete(result.orden_pagoId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<orden_pagoResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<orden_pago> items = await _orden_pagoRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<orden_pagoResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<orden_pagoResponse> GetById(int id)
        {
            try
            {
                var result = (await _orden_pagoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "orden_pago not found");
                }
                return _mapper.Map<orden_pagoResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<orden_pagoResponse> Update(orden_pagoRequest updatedorden_pago, string externalUserId)
        {
            var transaction = _orden_pagoRepository.BeginTransaction();
            try
            {

                var mappedorden_pago = (await _orden_pagoRepository.Get(updatedorden_pago.orden_pagoId)).FirstOrDefault();
		        var result = await _orden_pagoRepository.Update(mappedorden_pago);
                var mappedResponse = _mapper.Map<orden_pagoResponse>(result);
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
