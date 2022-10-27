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
    public class gastoxinstService : BaseService, IgastoxinstService
    {
        private readonly IgastoxinstRepository _gastoxinstRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public gastoxinstService(
            IgastoxinstRepository gastoxinstRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _gastoxinstRepository = gastoxinstRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<gastoxinstResponse> Create(gastoxinstRequest newgastoxinst, string externalUserId)
        {
            var transaction = _gastoxinstRepository.BeginTransaction();
            try
            {

                gastoxinst entity= _mapper.Map<gastoxinst>(newgastoxinst);
                var addedgastoxinst = await _gastoxinstRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<gastoxinstResponse>(addedgastoxinst);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id, string externalUserId)
        {
            var transaction = _gastoxinstRepository.BeginTransaction();
            try
            {
                var result = (await _gastoxinstRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "gastoxinst not found");
                }
                await _gastoxinstRepository.Delete(result.gastoxinstId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<gastoxinstResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<gastoxinst> items = await _gastoxinstRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<gastoxinstResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<gastoxinstResponse> GetById(int id)
        {
            try
            {
                var result = (await _gastoxinstRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "gastoxinst not found");
                }
                return _mapper.Map<gastoxinstResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<gastoxinstResponse> Update(gastoxinstRequest updatedgastoxinst, string externalUserId)
        {
            var transaction = _gastoxinstRepository.BeginTransaction();
            try
            {

                var mappedgastoxinst = (await _gastoxinstRepository.Get(updatedgastoxinst.gastoxinstId)).FirstOrDefault();
		        var result = await _gastoxinstRepository.Update(mappedgastoxinst);
                var mappedResponse = _mapper.Map<gastoxinstResponse>(result);
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
