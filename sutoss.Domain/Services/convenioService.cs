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
    public class conveniosService : BaseService, IconveniosService
    {
        private readonly IconvenioRepository _convenioRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public conveniosService(
            IconvenioRepository convenioRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _convenioRepository = convenioRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<convenioResponse> Create(convenioRequest newconvenio, string externalUserId)
        {
            var transaction = _convenioRepository.BeginTransaction();
            try
            {

                convenio entity= _mapper.Map<convenio>(newconvenio);
                var addedconvenio = await _convenioRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<convenioResponse>(addedconvenio);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id, string externalUserId)
        {
            var transaction = _convenioRepository.BeginTransaction();
            try
            {
                var result = (await _convenioRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "convenio not found");
                }
                await _convenioRepository.Delete(result.convenioId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<convenioResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<convenio> items = await _convenioRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<convenioResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<convenioResponse> GetById(int id)
        {
            try
            {
                var result = (await _convenioRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "convenio not found");
                }
                return _mapper.Map<convenioResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<convenioResponse> Update(convenioRequest updatedconvenio, string externalUserId)
        {
            var transaction = _convenioRepository.BeginTransaction();
            try
            {

                var mappedconvenio = (await _convenioRepository.Get(updatedconvenio.convenioId)).FirstOrDefault();
		        var result = await _convenioRepository.Update(mappedconvenio);
                var mappedResponse = _mapper.Map<convenioResponse>(result);
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
