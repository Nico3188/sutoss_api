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
    public class serviciosService : BaseService, IserviciosService
    {
        private readonly IservicioRepository _servicioRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public serviciosService(
            IservicioRepository servicioRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _servicioRepository = servicioRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<servicioResponse> Create(servicioRequest newservicio, string externalUserId)
        {
            var transaction = _servicioRepository.BeginTransaction();
            try
            {

                servicio entity= _mapper.Map<servicio>(newservicio);
                var addedservicio = await _servicioRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<servicioResponse>(addedservicio);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id, string externalUserId)
        {
            var transaction = _servicioRepository.BeginTransaction();
            try
            {
                var result = (await _servicioRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "servicio not found");
                }
                await _servicioRepository.Delete(result.servicioId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<servicioResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<servicio> items = await _servicioRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<servicioResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<servicioResponse> GetById(int id)
        {
            try
            {
                var result = (await _servicioRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "servicio not found");
                }
                return _mapper.Map<servicioResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<servicioResponse> Update(servicioRequest updatedservicio, string externalUserId)
        {
            var transaction = _servicioRepository.BeginTransaction();
            try
            {

                var mappedservicio = (await _servicioRepository.Get(updatedservicio.servicioId)).FirstOrDefault();
		        var result = await _servicioRepository.Update(mappedservicio);
                var mappedResponse = _mapper.Map<servicioResponse>(result);
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
