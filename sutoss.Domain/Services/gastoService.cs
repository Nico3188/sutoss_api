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
    public class gastosService : BaseService, IgastosService
    {
        private readonly IgastoRepository _gastoRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public gastosService(
            IgastoRepository gastoRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _gastoRepository = gastoRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<gastoResponse> Create(gastoRequest newgasto, string externalUserId)
        {
            var transaction = _gastoRepository.BeginTransaction();
            try
            {

                gasto entity= _mapper.Map<gasto>(newgasto);
                var addedgasto = await _gastoRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<gastoResponse>(addedgasto);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id, string externalUserId)
        {
            var transaction = _gastoRepository.BeginTransaction();
            try
            {
                var result = (await _gastoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "gasto not found");
                }
                await _gastoRepository.Delete(result.gastoId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<gastoResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<gasto> items = await _gastoRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<gastoResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<gastoResponse> GetById(int id)
        {
            try
            {
                var result = (await _gastoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "gasto not found");
                }
                return _mapper.Map<gastoResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<gastoResponse> Update(gastoRequest updatedgasto, string externalUserId)
        {
            var transaction = _gastoRepository.BeginTransaction();
            try
            {

                var mappedgasto = (await _gastoRepository.Get(updatedgasto.gastoId)).FirstOrDefault();
		        var result = await _gastoRepository.Update(mappedgasto);
                var mappedResponse = _mapper.Map<gastoResponse>(result);
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
