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
    public class impxinstalacionesService : BaseService, IimpxinstalacionesService
    {
        private readonly IimpxinstalacionRepository _impxinstalacionRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public impxinstalacionesService(
            IimpxinstalacionRepository impxinstalacionRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _impxinstalacionRepository = impxinstalacionRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<impxinstalacionResponse> Create(impxinstalacionRequest newimpxinstalacion, string externalUserId)
        {
            var transaction = _impxinstalacionRepository.BeginTransaction();
            try
            {

                impxinstalacion entity= _mapper.Map<impxinstalacion>(newimpxinstalacion);
                var addedimpxinstalacion = await _impxinstalacionRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<impxinstalacionResponse>(addedimpxinstalacion);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id, string externalUserId)
        {
            var transaction = _impxinstalacionRepository.BeginTransaction();
            try
            {
                var result = (await _impxinstalacionRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "impxinstalacion not found");
                }
                await _impxinstalacionRepository.Delete(result.impxinstalacionId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<impxinstalacionResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<impxinstalacion> items = await _impxinstalacionRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<impxinstalacionResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<impxinstalacionResponse> GetById(int id)
        {
            try
            {
                var result = (await _impxinstalacionRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "impxinstalacion not found");
                }
                return _mapper.Map<impxinstalacionResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<impxinstalacionResponse> Update(impxinstalacionRequest updatedimpxinstalacion, string externalUserId)
        {
            var transaction = _impxinstalacionRepository.BeginTransaction();
            try
            {

                var mappedimpxinstalacion = (await _impxinstalacionRepository.Get(updatedimpxinstalacion.impxinstalacionId)).FirstOrDefault();
		        var result = await _impxinstalacionRepository.Update(mappedimpxinstalacion);
                var mappedResponse = _mapper.Map<impxinstalacionResponse>(result);
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
