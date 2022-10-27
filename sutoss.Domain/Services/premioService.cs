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
    public class premiosService : BaseService, IpremiosService
    {
        private readonly IpremioRepository _premioRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public premiosService(
            IpremioRepository premioRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _premioRepository = premioRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<premioResponse> Create(premioRequest newpremio, string externalUserId)
        {
            var transaction = _premioRepository.BeginTransaction();
            try
            {

                premio entity= _mapper.Map<premio>(newpremio);
                var addedpremio = await _premioRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<premioResponse>(addedpremio);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id, string externalUserId)
        {
            var transaction = _premioRepository.BeginTransaction();
            try
            {
                var result = (await _premioRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "premio not found");
                }
                await _premioRepository.Delete(result.premioId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<premioResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<premio> items = await _premioRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<premioResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<premioResponse> GetById(int id)
        {
            try
            {
                var result = (await _premioRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "premio not found");
                }
                return _mapper.Map<premioResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<premioResponse> Update(premioRequest updatedpremio, string externalUserId)
        {
            var transaction = _premioRepository.BeginTransaction();
            try
            {

                var mappedpremio = (await _premioRepository.Get(updatedpremio.premioId)).FirstOrDefault();
		        var result = await _premioRepository.Update(mappedpremio);
                var mappedResponse = _mapper.Map<premioResponse>(result);
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
