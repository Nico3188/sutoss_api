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
    public class conveniosxprovService : BaseService, IconveniosxprovService
    {
        private readonly IconvenioxprovRepository _convenioxprovRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public conveniosxprovService(
            IconvenioxprovRepository convenioxprovRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _convenioxprovRepository = convenioxprovRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<convenioxprovResponse> Create(convenioxprovRequest newconvenioxprov, string externalUserId)
        {
            var transaction = _convenioxprovRepository.BeginTransaction();
            try
            {

                convenioxprov entity= _mapper.Map<convenioxprov>(newconvenioxprov);
                var addedconvenioxprov = await _convenioxprovRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<convenioxprovResponse>(addedconvenioxprov);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id, string externalUserId)
        {
            var transaction = _convenioxprovRepository.BeginTransaction();
            try
            {
                var result = (await _convenioxprovRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "convenioxprov not found");
                }
                await _convenioxprovRepository.Delete(result.convenioxprovId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<convenioxprovResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<convenioxprov> items = await _convenioxprovRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<convenioxprovResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<convenioxprovResponse> GetById(int id)
        {
            try
            {
                var result = (await _convenioxprovRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "convenioxprov not found");
                }
                return _mapper.Map<convenioxprovResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<convenioxprovResponse> Update(convenioxprovRequest updatedconvenioxprov, string externalUserId)
        {
            var transaction = _convenioxprovRepository.BeginTransaction();
            try
            {

                var mappedconvenioxprov = (await _convenioxprovRepository.Get(updatedconvenioxprov.convenioxprovId)).FirstOrDefault();
		        var result = await _convenioxprovRepository.Update(mappedconvenioxprov);
                var mappedResponse = _mapper.Map<convenioxprovResponse>(result);
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
