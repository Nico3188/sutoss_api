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
    public class facturasService : BaseService, IfacturasService
    {
        private readonly IfacturaRepository _facturaRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public facturasService(
            IfacturaRepository facturaRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _facturaRepository = facturaRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<facturaResponse> Create(facturaRequest newfactura, string externalUserId)
        {
            var transaction = _facturaRepository.BeginTransaction();
            try
            {

                factura entity= _mapper.Map<factura>(newfactura);
                var addedfactura = await _facturaRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<facturaResponse>(addedfactura);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id, string externalUserId)
        {
            var transaction = _facturaRepository.BeginTransaction();
            try
            {
                var result = (await _facturaRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "factura not found");
                }
                await _facturaRepository.Delete(result.facturaId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<facturaResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<factura> items = await _facturaRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<facturaResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<facturaResponse> GetById(int id)
        {
            try
            {
                var result = (await _facturaRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "factura not found");
                }
                return _mapper.Map<facturaResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<facturaResponse> Update(facturaRequest updatedfactura, string externalUserId)
        {
            var transaction = _facturaRepository.BeginTransaction();
            try
            {

                var mappedfactura = (await _facturaRepository.Get(updatedfactura.facturaId)).FirstOrDefault();
		        var result = await _facturaRepository.Update(mappedfactura);
                var mappedResponse = _mapper.Map<facturaResponse>(result);
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
