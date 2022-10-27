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
    public class HealtcareVisitsService : BaseService, IHealtcareVisitsService
    {
        private readonly IHealtcareVisitRepository _HealtcareVisitRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public HealtcareVisitsService(
            IHealtcareVisitRepository HealtcareVisitRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _HealtcareVisitRepository = HealtcareVisitRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<HealtcareVisitResponse> Create(HealtcareVisitRequest newHealtcareVisit)
        {
            var transaction = _HealtcareVisitRepository.BeginTransaction();
            try
            {

                HealtcareVisit entity= _mapper.Map<HealtcareVisit>(newHealtcareVisit);
                var addedHealtcareVisit = await _HealtcareVisitRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<HealtcareVisitResponse>(addedHealtcareVisit);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var transaction = _HealtcareVisitRepository.BeginTransaction();
            try
            {
                var result = (await _HealtcareVisitRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "HealtcareVisit not found");
                }
                await _HealtcareVisitRepository.Delete(result.HealtcareVisitId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<HealtcareVisitResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<HealtcareVisit> items = await _HealtcareVisitRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<HealtcareVisitResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<HealtcareVisitResponse> GetById(int id)
        {
            try
            {
                var result = (await _HealtcareVisitRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "HealtcareVisit not found");
                }
                return _mapper.Map<HealtcareVisitResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<HealtcareVisitResponse> Update(HealtcareVisitRequest updatedHealtcareVisit)
        {
            var transaction = _HealtcareVisitRepository.BeginTransaction();
            try
            {

                var mappedHealtcareVisit = (await _HealtcareVisitRepository.Get(updatedHealtcareVisit.HealtcareVisitId)).FirstOrDefault();
		        var result = await _HealtcareVisitRepository.Update(mappedHealtcareVisit);
                var mappedResponse = _mapper.Map<HealtcareVisitResponse>(result);
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
