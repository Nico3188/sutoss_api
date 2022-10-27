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
    public class anticiposService : BaseService, IanticiposService
    {
        private readonly IanticipoRepository _anticipoRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public anticiposService(
            IanticipoRepository anticipoRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _anticipoRepository = anticipoRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<anticipoResponse> Create(anticipoRequest newanticipo, string externalUserId)
        {
            var transaction = _anticipoRepository.BeginTransaction();
            try
            {

                anticipo entity= _mapper.Map<anticipo>(newanticipo);
                var addedanticipo = await _anticipoRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<anticipoResponse>(addedanticipo);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id, string externalUserId)
        {
            var transaction = _anticipoRepository.BeginTransaction();
            try
            {
                var result = (await _anticipoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "anticipo not found");
                }
                await _anticipoRepository.Delete(result.anticipoId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<anticipoResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<anticipo> items = await _anticipoRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<anticipoResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<anticipoResponse> GetById(int id)
        {
            try
            {
                var result = (await _anticipoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "anticipo not found");
                }
                return _mapper.Map<anticipoResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<anticipoResponse> Update(anticipoRequest updatedanticipo, string externalUserId)
        {
            var transaction = _anticipoRepository.BeginTransaction();
            try
            {

                var mappedanticipo = (await _anticipoRepository.Get(updatedanticipo.anticipoId)).FirstOrDefault();
		        var result = await _anticipoRepository.Update(mappedanticipo);
                var mappedResponse = _mapper.Map<anticipoResponse>(result);
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
