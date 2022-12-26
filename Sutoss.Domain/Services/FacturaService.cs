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
    public class FacturasService : BaseService, IFacturasService
    {
        private readonly IFacturaRepository _FacturaRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public FacturasService(
            IFacturaRepository FacturaRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _FacturaRepository = FacturaRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<FacturaResponse> Create(FacturaRequest newFactura )
        {
            var transaction = _FacturaRepository.BeginTransaction();
            try
            {

                Factura entity= _mapper.Map<Factura>(newFactura);
                var addedFactura = await _FacturaRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<FacturaResponse>(addedFactura);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {
            var transaction = _FacturaRepository.BeginTransaction();
            try
            {
                var result = (await _FacturaRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Factura not found");
                }
                await _FacturaRepository.Delete(result.IdFactura);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<FacturaResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<Factura> items = await _FacturaRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<FacturaResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<FacturaResponse> GetById(int id)
        {
            try
            {
                var result = (await _FacturaRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Factura not found");
                }
                return _mapper.Map<FacturaResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<FacturaResponse> Update(FacturaRequest updatedFactura )
        {
            var transaction = _FacturaRepository.BeginTransaction();
            try
            {

                var mappedFactura = (await _FacturaRepository.Get(updatedFactura.IdFactura)).FirstOrDefault();
		        var result = await _FacturaRepository.Update(mappedFactura);
                var mappedResponse = _mapper.Map<FacturaResponse>(result);
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
