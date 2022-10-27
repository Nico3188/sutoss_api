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
    public class cuotas_ppService : BaseService, Icuotas_ppService
    {
        private readonly Icuota_ppRepository _cuota_ppRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public cuotas_ppService(
            Icuota_ppRepository cuota_ppRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _cuota_ppRepository = cuota_ppRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<cuota_ppResponse> Create(cuota_ppRequest newcuota_pp, string externalUserId)
        {
            var transaction = _cuota_ppRepository.BeginTransaction();
            try
            {

                cuota_pp entity= _mapper.Map<cuota_pp>(newcuota_pp);
                var addedcuota_pp = await _cuota_ppRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<cuota_ppResponse>(addedcuota_pp);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id, string externalUserId)
        {
            var transaction = _cuota_ppRepository.BeginTransaction();
            try
            {
                var result = (await _cuota_ppRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "cuota_pp not found");
                }
                await _cuota_ppRepository.Delete(result.cuota_ppId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<cuota_ppResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<cuota_pp> items = await _cuota_ppRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<cuota_ppResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<cuota_ppResponse> GetById(int id)
        {
            try
            {
                var result = (await _cuota_ppRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "cuota_pp not found");
                }
                return _mapper.Map<cuota_ppResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<cuota_ppResponse> Update(cuota_ppRequest updatedcuota_pp, string externalUserId)
        {
            var transaction = _cuota_ppRepository.BeginTransaction();
            try
            {

                var mappedcuota_pp = (await _cuota_ppRepository.Get(updatedcuota_pp.cuota_ppId)).FirstOrDefault();
		        var result = await _cuota_ppRepository.Update(mappedcuota_pp);
                var mappedResponse = _mapper.Map<cuota_ppResponse>(result);
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
