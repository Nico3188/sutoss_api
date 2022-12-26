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
    public class DetalleFacturasService : BaseService, IDetalleFacturasService
    {
        private readonly IDetalleFacturaRepository _DetalleFacturaRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public DetalleFacturasService(
            IDetalleFacturaRepository DetalleFacturaRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _DetalleFacturaRepository = DetalleFacturaRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<DetalleFacturaResponse> Create(DetalleFacturaRequest newDetalleFactura )
        {
            var transaction = _DetalleFacturaRepository.BeginTransaction();
            try
            {

                DetalleFactura entity= _mapper.Map<DetalleFactura>(newDetalleFactura);
                var addedDetalleFactura = await _DetalleFacturaRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<DetalleFacturaResponse>(addedDetalleFactura);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {
            var transaction = _DetalleFacturaRepository.BeginTransaction();
            try
            {
                var result = (await _DetalleFacturaRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "DetalleFactura not found");
                }
                await _DetalleFacturaRepository.Delete(result.IddetalleFactura);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<DetalleFacturaResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<DetalleFactura> items = await _DetalleFacturaRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<DetalleFacturaResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DetalleFacturaResponse> GetById(int id)
        {
            try
            {
                var result = (await _DetalleFacturaRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "DetalleFactura not found");
                }
                return _mapper.Map<DetalleFacturaResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DetalleFacturaResponse> Update(DetalleFacturaRequest updatedDetalleFactura )
        {
            var transaction = _DetalleFacturaRepository.BeginTransaction();
            try
            {

                var mappedDetalleFactura = (await _DetalleFacturaRepository.Get(updatedDetalleFactura.IddetalleFactura)).FirstOrDefault();
		        var result = await _DetalleFacturaRepository.Update(mappedDetalleFactura);
                var mappedResponse = _mapper.Map<DetalleFacturaResponse>(result);
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
