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
    public class PedidoProductosService : BaseService, IPedidoProductosService
    {
        private readonly IPedidoProductoRepository _PedidoProductoRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public PedidoProductosService(
            IPedidoProductoRepository PedidoProductoRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _PedidoProductoRepository = PedidoProductoRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<PedidoProductoResponse> Create(PedidoProductoRequest newPedidoProducto )
        {
            var transaction = _PedidoProductoRepository.BeginTransaction();
            try
            {

                PedidoProducto entity= _mapper.Map<PedidoProducto>(newPedidoProducto);
                var addedPedidoProducto = await _PedidoProductoRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<PedidoProductoResponse>(addedPedidoProducto);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {
            var transaction = _PedidoProductoRepository.BeginTransaction();
            try
            {
                var result = (await _PedidoProductoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "PedidoProducto not found");
                }
                await _PedidoProductoRepository.Delete(result.IdPedidoProducto);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<PedidoProductoResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<PedidoProducto> items = await _PedidoProductoRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<PedidoProductoResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PedidoProductoResponse> GetById(int id)
        {
            try
            {
                var result = (await _PedidoProductoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "PedidoProducto not found");
                }
                return _mapper.Map<PedidoProductoResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PedidoProductoResponse> Update(PedidoProductoRequest updatedPedidoProducto )
        {
            var transaction = _PedidoProductoRepository.BeginTransaction();
            try
            {

                var mappedPedidoProducto = (await _PedidoProductoRepository.Get(updatedPedidoProducto.IdPedidoProducto)).FirstOrDefault();
		        var result = await _PedidoProductoRepository.Update(mappedPedidoProducto);
                var mappedResponse = _mapper.Map<PedidoProductoResponse>(result);
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
