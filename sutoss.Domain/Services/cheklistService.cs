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
    public class cheklistsService : BaseService, IcheklistsService
    {
        private readonly IcheklistRepository _cheklistRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public cheklistsService(
            IcheklistRepository cheklistRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _cheklistRepository = cheklistRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<cheklistResponse> Create(cheklistRequest newcheklist, string externalUserId)
        {
            var transaction = _cheklistRepository.BeginTransaction();
            try
            {

                cheklist entity= _mapper.Map<cheklist>(newcheklist);
                var addedcheklist = await _cheklistRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<cheklistResponse>(addedcheklist);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id, string externalUserId)
        {
            var transaction = _cheklistRepository.BeginTransaction();
            try
            {
                var result = (await _cheklistRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "cheklist not found");
                }
                await _cheklistRepository.Delete(result.cheklistId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<cheklistResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<cheklist> items = await _cheklistRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<cheklistResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<cheklistResponse> GetById(int id)
        {
            try
            {
                var result = (await _cheklistRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "cheklist not found");
                }
                return _mapper.Map<cheklistResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<cheklistResponse> Update(cheklistRequest updatedcheklist, string externalUserId)
        {
            var transaction = _cheklistRepository.BeginTransaction();
            try
            {

                var mappedcheklist = (await _cheklistRepository.Get(updatedcheklist.cheklistId)).FirstOrDefault();
		        var result = await _cheklistRepository.Update(mappedcheklist);
                var mappedResponse = _mapper.Map<cheklistResponse>(result);
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
