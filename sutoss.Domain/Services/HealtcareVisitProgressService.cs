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
    public class HealtcareVisitProgressesService : BaseService, IHealtcareVisitProgressesService
    {
        private readonly IHealtcareVisitProgressRepository _HealtcareVisitProgressRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public HealtcareVisitProgressesService(
            IHealtcareVisitProgressRepository HealtcareVisitProgressRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _HealtcareVisitProgressRepository = HealtcareVisitProgressRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<HealtcareVisitProgressResponse> Create(HealtcareVisitProgressRequest newHealtcareVisitProgress)
        {
            var transaction = _HealtcareVisitProgressRepository.BeginTransaction();
            try
            {

                HealtcareVisitProgress entity= _mapper.Map<HealtcareVisitProgress>(newHealtcareVisitProgress);
                var addedHealtcareVisitProgress = await _HealtcareVisitProgressRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<HealtcareVisitProgressResponse>(addedHealtcareVisitProgress);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var transaction = _HealtcareVisitProgressRepository.BeginTransaction();
            try
            {
                var result = (await _HealtcareVisitProgressRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "HealtcareVisitProgress not found");
                }
                await _HealtcareVisitProgressRepository.Delete(result.HealtcareVisitProgressId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<HealtcareVisitProgressResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<HealtcareVisitProgress> items = await _HealtcareVisitProgressRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<HealtcareVisitProgressResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<HealtcareVisitProgressResponse> GetById(int id)
        {
            try
            {
                var result = (await _HealtcareVisitProgressRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "HealtcareVisitProgress not found");
                }
                return _mapper.Map<HealtcareVisitProgressResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<HealtcareVisitProgressResponse> Update(HealtcareVisitProgressRequest updatedHealtcareVisitProgress)
        {
            var transaction = _HealtcareVisitProgressRepository.BeginTransaction();
            try
            {

                var mappedHealtcareVisitProgress = (await _HealtcareVisitProgressRepository.Get(updatedHealtcareVisitProgress.HealtcareVisitProgressId)).FirstOrDefault();
		        var result = await _HealtcareVisitProgressRepository.Update(mappedHealtcareVisitProgress);
                var mappedResponse = _mapper.Map<HealtcareVisitProgressResponse>(result);
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
