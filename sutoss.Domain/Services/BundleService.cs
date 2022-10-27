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
    public class BundlesService : BaseService, IBundlesService
    {
        private readonly IBundleRepository _BundleRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public BundlesService(
            IBundleRepository BundleRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _BundleRepository = BundleRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<BundleResponse> Create(BundleRequest newBundle)
        {
            var transaction = _BundleRepository.BeginTransaction();
            try
            {

                Bundle entity= _mapper.Map<Bundle>(newBundle);
                var addedBundle = await _BundleRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<BundleResponse>(addedBundle);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var transaction = _BundleRepository.BeginTransaction();
            try
            {
                var result = (await _BundleRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Bundle not found");
                }
                await _BundleRepository.Delete(result.BundleId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<BundleResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<Bundle> items = await _BundleRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<BundleResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BundleResponse> GetById(int id)
        {
            try
            {
                var result = (await _BundleRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Bundle not found");
                }
                return _mapper.Map<BundleResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BundleResponse> Update(BundleRequest updatedBundle)
        {
            var transaction = _BundleRepository.BeginTransaction();
            try
            {

                var mappedBundle = (await _BundleRepository.Get(updatedBundle.BundleId)).FirstOrDefault();
		        var result = await _BundleRepository.Update(mappedBundle);
                var mappedResponse = _mapper.Map<BundleResponse>(result);
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
