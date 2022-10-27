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
    public class cuotasService : BaseService, IcuotasService
    {
        private readonly IcuotaRepository _cuotaRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public cuotasService(
            IcuotaRepository cuotaRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _cuotaRepository = cuotaRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<cuotaResponse> Create(cuotaRequest newcuota, string externalUserId)
        {
            var transaction = _cuotaRepository.BeginTransaction();
            try
            {

                cuota entity= _mapper.Map<cuota>(newcuota);
                var addedcuota = await _cuotaRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<cuotaResponse>(addedcuota);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id, string externalUserId)
        {
            var transaction = _cuotaRepository.BeginTransaction();
            try
            {
                var result = (await _cuotaRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "cuota not found");
                }
                await _cuotaRepository.Delete(result.cuotaId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<cuotaResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<cuota> items = await _cuotaRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<cuotaResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<cuotaResponse> GetById(int id)
        {
            try
            {
                var result = (await _cuotaRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "cuota not found");
                }
                return _mapper.Map<cuotaResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<cuotaResponse> Update(cuotaRequest updatedcuota, string externalUserId)
        {
            var transaction = _cuotaRepository.BeginTransaction();
            try
            {

                var mappedcuota = (await _cuotaRepository.Get(updatedcuota.cuotaId)).FirstOrDefault();
		        var result = await _cuotaRepository.Update(mappedcuota);
                var mappedResponse = _mapper.Map<cuotaResponse>(result);
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
