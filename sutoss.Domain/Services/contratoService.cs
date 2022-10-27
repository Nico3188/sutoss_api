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
    public class contartosService : BaseService, IcontartosService
    {
        private readonly IcontratoRepository _contratoRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public contartosService(
            IcontratoRepository contratoRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _contratoRepository = contratoRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<contratoResponse> Create(contratoRequest newcontrato, string externalUserId)
        {
            var transaction = _contratoRepository.BeginTransaction();
            try
            {

                contrato entity= _mapper.Map<contrato>(newcontrato);
                var addedcontrato = await _contratoRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<contratoResponse>(addedcontrato);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id, string externalUserId)
        {
            var transaction = _contratoRepository.BeginTransaction();
            try
            {
                var result = (await _contratoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "contrato not found");
                }
                await _contratoRepository.Delete(result.contratoId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<contratoResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<contrato> items = await _contratoRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<contratoResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<contratoResponse> GetById(int id)
        {
            try
            {
                var result = (await _contratoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "contrato not found");
                }
                return _mapper.Map<contratoResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<contratoResponse> Update(contratoRequest updatedcontrato, string externalUserId)
        {
            var transaction = _contratoRepository.BeginTransaction();
            try
            {

                var mappedcontrato = (await _contratoRepository.Get(updatedcontrato.contratoId)).FirstOrDefault();
		        var result = await _contratoRepository.Update(mappedcontrato);
                var mappedResponse = _mapper.Map<contratoResponse>(result);
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
