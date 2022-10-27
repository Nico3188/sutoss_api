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
    public class ServicesService : BaseService, IServicesService
    {
        private readonly IServiceRepository _ServiceRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public ServicesService(
            IServiceRepository ServiceRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _ServiceRepository = ServiceRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<ServiceResponse> Create(ServiceRequest newService)
        {
            var transaction = _ServiceRepository.BeginTransaction();
            try
            {

                Service entity= _mapper.Map<Service>(newService);
                var addedService = await _ServiceRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<ServiceResponse>(addedService);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var transaction = _ServiceRepository.BeginTransaction();
            try
            {
                var result = (await _ServiceRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Service not found");
                }
                await _ServiceRepository.Delete(result.ServiceId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<ServiceResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<Service> items = await _ServiceRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<ServiceResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ServiceResponse> GetById(int id)
        {
            try
            {
                var result = (await _ServiceRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Service not found");
                }
                return _mapper.Map<ServiceResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ServiceResponse> Update(ServiceRequest updatedService)
        {
            var transaction = _ServiceRepository.BeginTransaction();
            try
            {

                var mappedService = (await _ServiceRepository.Get(updatedService.ServiceId)).FirstOrDefault();
		        var result = await _ServiceRepository.Update(mappedService);
                var mappedResponse = _mapper.Map<ServiceResponse>(result);
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
