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
    public class fromas_pagoService : BaseService, Ifromas_pagoService
    {
        private readonly Iforma_pagoRepository _forma_pagoRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public fromas_pagoService(
            Iforma_pagoRepository forma_pagoRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _forma_pagoRepository = forma_pagoRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<forma_pagoResponse> Create(forma_pagoRequest newforma_pago, string externalUserId)
        {
            var transaction = _forma_pagoRepository.BeginTransaction();
            try
            {

                forma_pago entity= _mapper.Map<forma_pago>(newforma_pago);
                var addedforma_pago = await _forma_pagoRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<forma_pagoResponse>(addedforma_pago);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id, string externalUserId)
        {
            var transaction = _forma_pagoRepository.BeginTransaction();
            try
            {
                var result = (await _forma_pagoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "forma_pago not found");
                }
                await _forma_pagoRepository.Delete(result.forma_pagoId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<forma_pagoResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<forma_pago> items = await _forma_pagoRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<forma_pagoResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<forma_pagoResponse> GetById(int id)
        {
            try
            {
                var result = (await _forma_pagoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "forma_pago not found");
                }
                return _mapper.Map<forma_pagoResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<forma_pagoResponse> Update(forma_pagoRequest updatedforma_pago, string externalUserId)
        {
            var transaction = _forma_pagoRepository.BeginTransaction();
            try
            {

                var mappedforma_pago = (await _forma_pagoRepository.Get(updatedforma_pago.forma_pagoId)).FirstOrDefault();
		        var result = await _forma_pagoRepository.Update(mappedforma_pago);
                var mappedResponse = _mapper.Map<forma_pagoResponse>(result);
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
