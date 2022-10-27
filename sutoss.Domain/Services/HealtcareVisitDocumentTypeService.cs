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
    public class HealtcareVisitDocumentTypesService : BaseService, IHealtcareVisitDocumentTypesService
    {
        private readonly IHealtcareVisitDocumentTypeRepository _HealtcareVisitDocumentTypeRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public HealtcareVisitDocumentTypesService(
            IHealtcareVisitDocumentTypeRepository HealtcareVisitDocumentTypeRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _HealtcareVisitDocumentTypeRepository = HealtcareVisitDocumentTypeRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<HealtcareVisitDocumentTypeResponse> Create(HealtcareVisitDocumentTypeRequest newHealtcareVisitDocumentType)
        {
            var transaction = _HealtcareVisitDocumentTypeRepository.BeginTransaction();
            try
            {

                HealtcareVisitDocumentType entity= _mapper.Map<HealtcareVisitDocumentType>(newHealtcareVisitDocumentType);
                var addedHealtcareVisitDocumentType = await _HealtcareVisitDocumentTypeRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<HealtcareVisitDocumentTypeResponse>(addedHealtcareVisitDocumentType);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var transaction = _HealtcareVisitDocumentTypeRepository.BeginTransaction();
            try
            {
                var result = (await _HealtcareVisitDocumentTypeRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "HealtcareVisitDocumentType not found");
                }
                await _HealtcareVisitDocumentTypeRepository.Delete(result.HealtcareVisitDocumentTypeId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<HealtcareVisitDocumentTypeResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<HealtcareVisitDocumentType> items = await _HealtcareVisitDocumentTypeRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<HealtcareVisitDocumentTypeResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<HealtcareVisitDocumentTypeResponse> GetById(int id)
        {
            try
            {
                var result = (await _HealtcareVisitDocumentTypeRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "HealtcareVisitDocumentType not found");
                }
                return _mapper.Map<HealtcareVisitDocumentTypeResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<HealtcareVisitDocumentTypeResponse> Update(HealtcareVisitDocumentTypeRequest updatedHealtcareVisitDocumentType)
        {
            var transaction = _HealtcareVisitDocumentTypeRepository.BeginTransaction();
            try
            {

                var mappedHealtcareVisitDocumentType = (await _HealtcareVisitDocumentTypeRepository.Get(updatedHealtcareVisitDocumentType.HealtcareVisitDocumentTypeId)).FirstOrDefault();
		        var result = await _HealtcareVisitDocumentTypeRepository.Update(mappedHealtcareVisitDocumentType);
                var mappedResponse = _mapper.Map<HealtcareVisitDocumentTypeResponse>(result);
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
