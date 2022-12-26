using AutoMapper;
using Sutoss.Domain.Services.Domain.Filters;
using Sutoss.Domain.Services.Domain.Repositories.Interfaces;
using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using Sutoss.Domain.Services.Domain.Services.Base;
using Sutoss.Domain.Services.Domain.Services.Interfaces;
using Sutoss.Domain.Services.Exceptions;
using Sutoss.Domain.Services.Helpers;
using Sutoss.Domain.Services.Repositories;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace Sutoss.Domain.Services.Domain.Services
{
    public class OrdenPagosService : BaseService, IOrdenPagosService
    {
        private readonly IOrdenPagoRepository _OrdenPagoRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public OrdenPagosService(
            IOrdenPagoRepository OrdenPagoRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _OrdenPagoRepository = OrdenPagoRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<OrdenPagoResponse> Create(OrdenPagoRequest newOrdenPago )
        {
            var transaction = _OrdenPagoRepository.BeginTransaction();
            try
            {

                OrdenPago entity= _mapper.Map<OrdenPago>(newOrdenPago);
                var addedOrdenPago = await _OrdenPagoRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<OrdenPagoResponse>(addedOrdenPago);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {
            var transaction = _OrdenPagoRepository.BeginTransaction();
            try
            {
                var result = (await _OrdenPagoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "OrdenPago not found");
                }
                await _OrdenPagoRepository.Delete(result.IdRdenPago);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<OrdenPagoResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<OrdenPago> items = await _OrdenPagoRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<OrdenPagoResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<OrdenPagoResponse> GetById(int id)
        {
            try
            {
                var result = (await _OrdenPagoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "OrdenPago not found");
                }
                return _mapper.Map<OrdenPagoResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<OrdenPagoResponse> Update(OrdenPagoRequest updatedOrdenPago )
        {
            var transaction = _OrdenPagoRepository.BeginTransaction();
            try
            {

                var mappedOrdenPago = (await _OrdenPagoRepository.Get(updatedOrdenPago.IdRdenPago)).FirstOrDefault();
		        var result = await _OrdenPagoRepository.Update(mappedOrdenPago);
                var mappedResponse = _mapper.Map<OrdenPagoResponse>(result);
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
