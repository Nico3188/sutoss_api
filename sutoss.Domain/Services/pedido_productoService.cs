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
    public class pedidos_productosService : BaseService, Ipedidos_productosService
    {
        private readonly Ipedido_productoRepository _pedido_productoRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public pedidos_productosService(
            Ipedido_productoRepository pedido_productoRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _pedido_productoRepository = pedido_productoRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<pedido_productoResponse> Create(pedido_productoRequest newpedido_producto, string externalUserId)
        {
            var transaction = _pedido_productoRepository.BeginTransaction();
            try
            {

                pedido_producto entity= _mapper.Map<pedido_producto>(newpedido_producto);
                var addedpedido_producto = await _pedido_productoRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<pedido_productoResponse>(addedpedido_producto);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id, string externalUserId)
        {
            var transaction = _pedido_productoRepository.BeginTransaction();
            try
            {
                var result = (await _pedido_productoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "pedido_producto not found");
                }
                await _pedido_productoRepository.Delete(result.pedido_productoId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<pedido_productoResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<pedido_producto> items = await _pedido_productoRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<pedido_productoResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<pedido_productoResponse> GetById(int id)
        {
            try
            {
                var result = (await _pedido_productoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "pedido_producto not found");
                }
                return _mapper.Map<pedido_productoResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<pedido_productoResponse> Update(pedido_productoRequest updatedpedido_producto, string externalUserId)
        {
            var transaction = _pedido_productoRepository.BeginTransaction();
            try
            {

                var mappedpedido_producto = (await _pedido_productoRepository.Get(updatedpedido_producto.pedido_productoId)).FirstOrDefault();
		        var result = await _pedido_productoRepository.Update(mappedpedido_producto);
                var mappedResponse = _mapper.Map<pedido_productoResponse>(result);
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
