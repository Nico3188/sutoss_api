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
    public class instalacionesService : BaseService, IinstalacionesService
    {
        private readonly IinstalacionRepository _instalacionRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public instalacionesService(
            IinstalacionRepository instalacionRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _instalacionRepository = instalacionRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<instalacionResponse> Create(instalacionRequest newinstalacion, string externalUserId)
        {
            var transaction = _instalacionRepository.BeginTransaction();
            try
            {

                instalacion entity= _mapper.Map<instalacion>(newinstalacion);
                var addedinstalacion = await _instalacionRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<instalacionResponse>(addedinstalacion);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id, string externalUserId)
        {
            var transaction = _instalacionRepository.BeginTransaction();
            try
            {
                var result = (await _instalacionRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "instalacion not found");
                }
                await _instalacionRepository.Delete(result.instalacionId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<instalacionResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<instalacion> items = await _instalacionRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<instalacionResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<instalacionResponse> GetById(int id)
        {
            try
            {
                var result = (await _instalacionRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "instalacion not found");
                }
                return _mapper.Map<instalacionResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<instalacionResponse> Update(instalacionRequest updatedinstalacion, string externalUserId)
        {
            var transaction = _instalacionRepository.BeginTransaction();
            try
            {

                var mappedinstalacion = (await _instalacionRepository.Get(updatedinstalacion.instalacionId)).FirstOrDefault();
		        var result = await _instalacionRepository.Update(mappedinstalacion);
                var mappedResponse = _mapper.Map<instalacionResponse>(result);
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
