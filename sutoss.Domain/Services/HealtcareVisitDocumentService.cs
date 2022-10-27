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
    public class HealtcareVisitDocumentsService : BaseService, IHealtcareVisitDocumentsService
    {
        private readonly IHealtcareVisitDocumentRepository _HealtcareVisitDocumentRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public HealtcareVisitDocumentsService(
            IHealtcareVisitDocumentRepository HealtcareVisitDocumentRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _HealtcareVisitDocumentRepository = HealtcareVisitDocumentRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<HealtcareVisitDocumentResponse> Create(HealtcareVisitDocumentRequest newHealtcareVisitDocument)
        {
            var transaction = _HealtcareVisitDocumentRepository.BeginTransaction();
            try
            {

                HealtcareVisitDocument entity= _mapper.Map<HealtcareVisitDocument>(newHealtcareVisitDocument);
                var addedHealtcareVisitDocument = await _HealtcareVisitDocumentRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<HealtcareVisitDocumentResponse>(addedHealtcareVisitDocument);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var transaction = _HealtcareVisitDocumentRepository.BeginTransaction();
            try
            {
                var result = (await _HealtcareVisitDocumentRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "HealtcareVisitDocument not found");
                }
                await _HealtcareVisitDocumentRepository.Delete(result.HealtcareVisitDocumentId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<HealtcareVisitDocumentResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<HealtcareVisitDocument> items = await _HealtcareVisitDocumentRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<HealtcareVisitDocumentResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<HealtcareVisitDocumentResponse> GetById(int id)
        {
            try
            {
                var result = (await _HealtcareVisitDocumentRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "HealtcareVisitDocument not found");
                }
                return _mapper.Map<HealtcareVisitDocumentResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<HealtcareVisitDocumentResponse> Update(HealtcareVisitDocumentRequest updatedHealtcareVisitDocument)
        {
            var transaction = _HealtcareVisitDocumentRepository.BeginTransaction();
            try
            {

                var mappedHealtcareVisitDocument = (await _HealtcareVisitDocumentRepository.Get(updatedHealtcareVisitDocument.HealtcareVisitDocumentId)).FirstOrDefault();
		        var result = await _HealtcareVisitDocumentRepository.Update(mappedHealtcareVisitDocument);
                var mappedResponse = _mapper.Map<HealtcareVisitDocumentResponse>(result);
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
