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
    public class vinculosService : BaseService, IvinculosService
    {
        private readonly IvinculoRepository _vinculoRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public vinculosService(
            IvinculoRepository vinculoRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _vinculoRepository = vinculoRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<vinculoResponse> Create(vinculoRequest newvinculo, string externalUserId)
        {
            var transaction = _vinculoRepository.BeginTransaction();
            try
            {

                vinculo entity= _mapper.Map<vinculo>(newvinculo);
                var addedvinculo = await _vinculoRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<vinculoResponse>(addedvinculo);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id, string externalUserId)
        {
            var transaction = _vinculoRepository.BeginTransaction();
            try
            {
                var result = (await _vinculoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "vinculo not found");
                }
                await _vinculoRepository.Delete(result.vinculoId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<vinculoResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<vinculo> items = await _vinculoRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<vinculoResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<vinculoResponse> GetById(int id)
        {
            try
            {
                var result = (await _vinculoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "vinculo not found");
                }
                return _mapper.Map<vinculoResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<vinculoResponse> Update(vinculoRequest updatedvinculo, string externalUserId)
        {
            var transaction = _vinculoRepository.BeginTransaction();
            try
            {

                var mappedvinculo = (await _vinculoRepository.Get(updatedvinculo.vinculoId)).FirstOrDefault();
		        var result = await _vinculoRepository.Update(mappedvinculo);
                var mappedResponse = _mapper.Map<vinculoResponse>(result);
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
