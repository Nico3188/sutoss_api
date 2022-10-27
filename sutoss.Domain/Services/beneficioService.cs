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
    public class beneficiosService : BaseService, IbeneficiosService
    {
        private readonly IBeneficioRepository _beneficioRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public beneficiosService(
            IBeneficioRepository beneficioRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _beneficioRepository = beneficioRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<beneficioResponse> Create(beneficioRequest newbeneficio, string externalUserId)
        {
            var transaction = _beneficioRepository.BeginTransaction();
            try
            {

                beneficio entity= _mapper.Map<beneficio>(newbeneficio);
                var addedbeneficio = await _beneficioRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<beneficioResponse>(addedbeneficio);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id, string externalUserId)
        {
            var transaction = _beneficioRepository.BeginTransaction();
            try
            {
                var result = (await _beneficioRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "beneficio not found");
                }
                await _beneficioRepository.Delete(result.beneficioId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<beneficioResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<beneficio> items = await _beneficioRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<beneficioResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<beneficioResponse> GetById(int id)
        {
            try
            {
                var result = (await _beneficioRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "beneficio not found");
                }
                return _mapper.Map<beneficioResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<beneficioResponse> Update(beneficioRequest updatedbeneficio, string externalUserId)
        {
            var transaction = _beneficioRepository.BeginTransaction();
            try
            {

                var mappedbeneficio = (await _beneficioRepository.Get(updatedbeneficio.beneficioId)).FirstOrDefault();
		        var result = await _beneficioRepository.Update(mappedbeneficio);
                var mappedResponse = _mapper.Map<beneficioResponse>(result);
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
