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
    public class ServiceItemsService : BaseService, IServiceItemsService
    {
        private readonly IServiceItemRepository _ServiceItemRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public ServiceItemsService(
            IServiceItemRepository ServiceItemRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _ServiceItemRepository = ServiceItemRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<ServiceItemResponse> Create(ServiceItemRequest newServiceItem)
        {
            var transaction = _ServiceItemRepository.BeginTransaction();
            try
            {

                ServiceItem entity= _mapper.Map<ServiceItem>(newServiceItem);
                var addedServiceItem = await _ServiceItemRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<ServiceItemResponse>(addedServiceItem);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var transaction = _ServiceItemRepository.BeginTransaction();
            try
            {
                var result = (await _ServiceItemRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "ServiceItem not found");
                }
                await _ServiceItemRepository.Delete(result.ServiceItemId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<ServiceItemResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<ServiceItem> items = await _ServiceItemRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<ServiceItemResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ServiceItemResponse> GetById(int id)
        {
            try
            {
                var result = (await _ServiceItemRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "ServiceItem not found");
                }
                return _mapper.Map<ServiceItemResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ServiceItemResponse> Update(ServiceItemRequest updatedServiceItem)
        {
            var transaction = _ServiceItemRepository.BeginTransaction();
            try
            {

                var mappedServiceItem = (await _ServiceItemRepository.Get(updatedServiceItem.ServiceItemId)).FirstOrDefault();
		        var result = await _ServiceItemRepository.Update(mappedServiceItem);
                var mappedResponse = _mapper.Map<ServiceItemResponse>(result);
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
