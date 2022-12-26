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
    public class ProductosService : BaseService, IProductosService
    {
        private readonly IProductoRepository _ProductoRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public ProductosService(
            IProductoRepository ProductoRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _ProductoRepository = ProductoRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<ProductoResponse> Create(ProductoRequest newProducto )
        {
            var transaction = _ProductoRepository.BeginTransaction();
            try
            {

                Producto entity= _mapper.Map<Producto>(newProducto);
                var addedProducto = await _ProductoRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<ProductoResponse>(addedProducto);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {
            var transaction = _ProductoRepository.BeginTransaction();
            try
            {
                var result = (await _ProductoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Producto not found");
                }
                await _ProductoRepository.Delete(result.IdProducto);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<ProductoResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<Producto> items = await _ProductoRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<ProductoResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProductoResponse> GetById(int id)
        {
            try
            {
                var result = (await _ProductoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Producto not found");
                }
                return _mapper.Map<ProductoResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProductoResponse> Update(ProductoRequest updatedProducto )
        {
            var transaction = _ProductoRepository.BeginTransaction();
            try
            {

                var mappedProducto = (await _ProductoRepository.Get(updatedProducto.IdProducto)).FirstOrDefault();
		        var result = await _ProductoRepository.Update(mappedProducto);
                var mappedResponse = _mapper.Map<ProductoResponse>(result);
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
