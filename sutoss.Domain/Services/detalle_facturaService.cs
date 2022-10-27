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
    public class detalle_facturasService : BaseService, Idetalle_facturasService
    {
        private readonly Idetalle_facturaRepository _detalle_facturaRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public detalle_facturasService(
            Idetalle_facturaRepository detalle_facturaRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _detalle_facturaRepository = detalle_facturaRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<detalle_facturaResponse> Create(detalle_facturaRequest newdetalle_factura, string externalUserId)
        {
            var transaction = _detalle_facturaRepository.BeginTransaction();
            try
            {

                detalle_factura entity= _mapper.Map<detalle_factura>(newdetalle_factura);
                var addeddetalle_factura = await _detalle_facturaRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<detalle_facturaResponse>(addeddetalle_factura);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id, string externalUserId)
        {
            var transaction = _detalle_facturaRepository.BeginTransaction();
            try
            {
                var result = (await _detalle_facturaRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "detalle_factura not found");
                }
                await _detalle_facturaRepository.Delete(result.detalle_facturaId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<detalle_facturaResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<detalle_factura> items = await _detalle_facturaRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<detalle_facturaResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<detalle_facturaResponse> GetById(int id)
        {
            try
            {
                var result = (await _detalle_facturaRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "detalle_factura not found");
                }
                return _mapper.Map<detalle_facturaResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<detalle_facturaResponse> Update(detalle_facturaRequest updateddetalle_factura, string externalUserId)
        {
            var transaction = _detalle_facturaRepository.BeginTransaction();
            try
            {

                var mappeddetalle_factura = (await _detalle_facturaRepository.Get(updateddetalle_factura.detalle_facturaId)).FirstOrDefault();
		        var result = await _detalle_facturaRepository.Update(mappeddetalle_factura);
                var mappedResponse = _mapper.Map<detalle_facturaResponse>(result);
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
