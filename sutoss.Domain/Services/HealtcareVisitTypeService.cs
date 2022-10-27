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
    public class HealtcareVisitTypesService : BaseService, IHealtcareVisitTypesService
    {
        private readonly IHealtcareVisitTypeRepository _HealtcareVisitTypeRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public HealtcareVisitTypesService(
            IHealtcareVisitTypeRepository HealtcareVisitTypeRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _HealtcareVisitTypeRepository = HealtcareVisitTypeRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<HealtcareVisitTypeResponse> Create(HealtcareVisitTypeRequest newHealtcareVisitType)
        {
            var transaction = _HealtcareVisitTypeRepository.BeginTransaction();
            try
            {

                HealtcareVisitType entity= _mapper.Map<HealtcareVisitType>(newHealtcareVisitType);
                var addedHealtcareVisitType = await _HealtcareVisitTypeRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<HealtcareVisitTypeResponse>(addedHealtcareVisitType);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var transaction = _HealtcareVisitTypeRepository.BeginTransaction();
            try
            {
                var result = (await _HealtcareVisitTypeRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "HealtcareVisitType not found");
                }
                await _HealtcareVisitTypeRepository.Delete(result.HealtcareVisitTypeId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<HealtcareVisitTypeResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<HealtcareVisitType> items = await _HealtcareVisitTypeRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<HealtcareVisitTypeResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<HealtcareVisitTypeResponse> GetById(int id)
        {
            try
            {
                var result = (await _HealtcareVisitTypeRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "HealtcareVisitType not found");
                }
                return _mapper.Map<HealtcareVisitTypeResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<HealtcareVisitTypeResponse> Update(HealtcareVisitTypeRequest updatedHealtcareVisitType)
        {
            var transaction = _HealtcareVisitTypeRepository.BeginTransaction();
            try
            {

                var mappedHealtcareVisitType = (await _HealtcareVisitTypeRepository.Get(updatedHealtcareVisitType.HealtcareVisitTypeId)).FirstOrDefault();
		        var result = await _HealtcareVisitTypeRepository.Update(mappedHealtcareVisitType);
                var mappedResponse = _mapper.Map<HealtcareVisitTypeResponse>(result);
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
