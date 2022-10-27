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
    public class designacionesService : BaseService, IdesignacionesService
    {
        private readonly IdesignacionRepository _designacionRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public designacionesService(
            IdesignacionRepository designacionRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _designacionRepository = designacionRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<designacionResponse> Create(designacionRequest newdesignacion, string externalUserId)
        {
            var transaction = _designacionRepository.BeginTransaction();
            try
            {

                designacion entity= _mapper.Map<designacion>(newdesignacion);
                var addeddesignacion = await _designacionRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<designacionResponse>(addeddesignacion);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id, string externalUserId)
        {
            var transaction = _designacionRepository.BeginTransaction();
            try
            {
                var result = (await _designacionRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "designacion not found");
                }
                await _designacionRepository.Delete(result.designacionId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<designacionResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<designacion> items = await _designacionRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<designacionResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<designacionResponse> GetById(int id)
        {
            try
            {
                var result = (await _designacionRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "designacion not found");
                }
                return _mapper.Map<designacionResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<designacionResponse> Update(designacionRequest updateddesignacion, string externalUserId)
        {
            var transaction = _designacionRepository.BeginTransaction();
            try
            {

                var mappeddesignacion = (await _designacionRepository.Get(updateddesignacion.designacionId)).FirstOrDefault();
		        var result = await _designacionRepository.Update(mappeddesignacion);
                var mappedResponse = _mapper.Map<designacionResponse>(result);
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
