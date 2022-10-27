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
    public class diasService : BaseService, IdiasService
    {
        private readonly IdiaRepository _diaRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public diasService(
            IdiaRepository diaRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _diaRepository = diaRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<diaResponse> Create(diaRequest newdia, string externalUserId)
        {
            var transaction = _diaRepository.BeginTransaction();
            try
            {

                dia entity= _mapper.Map<dia>(newdia);
                var addeddia = await _diaRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<diaResponse>(addeddia);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id, string externalUserId)
        {
            var transaction = _diaRepository.BeginTransaction();
            try
            {
                var result = (await _diaRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "dia not found");
                }
                await _diaRepository.Delete(result.diaId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<diaResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<dia> items = await _diaRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<diaResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<diaResponse> GetById(int id)
        {
            try
            {
                var result = (await _diaRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "dia not found");
                }
                return _mapper.Map<diaResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<diaResponse> Update(diaRequest updateddia, string externalUserId)
        {
            var transaction = _diaRepository.BeginTransaction();
            try
            {

                var mappeddia = (await _diaRepository.Get(updateddia.diaId)).FirstOrDefault();
		        var result = await _diaRepository.Update(mappeddia);
                var mappedResponse = _mapper.Map<diaResponse>(result);
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
