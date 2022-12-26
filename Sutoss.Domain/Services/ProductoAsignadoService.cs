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
    public class ProductoAsignadosService : BaseService, IProductoAsignadosService
    {
        private readonly IProductoAsignadoRepository _ProductoAsignadoRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public ProductoAsignadosService(
            IProductoAsignadoRepository ProductoAsignadoRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _ProductoAsignadoRepository = ProductoAsignadoRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<ProductoAsignadoResponse> Create(ProductoAsignadoRequest newProductoAsignado )
        {
            var transaction = _ProductoAsignadoRepository.BeginTransaction();
            try
            {

                ProductoAsignado entity= _mapper.Map<ProductoAsignado>(newProductoAsignado);
                var addedProductoAsignado = await _ProductoAsignadoRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<ProductoAsignadoResponse>(addedProductoAsignado);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {
            var transaction = _ProductoAsignadoRepository.BeginTransaction();
            try
            {
                var result = (await _ProductoAsignadoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "ProductoAsignado not found");
                }
                await _ProductoAsignadoRepository.Delete(result.IdProductoAsignado);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<ProductoAsignadoResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<ProductoAsignado> items = await _ProductoAsignadoRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<ProductoAsignadoResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProductoAsignadoResponse> GetById(int id)
        {
            try
            {
                var result = (await _ProductoAsignadoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "ProductoAsignado not found");
                }
                return _mapper.Map<ProductoAsignadoResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProductoAsignadoResponse> Update(ProductoAsignadoRequest updatedProductoAsignado )
        {
            var transaction = _ProductoAsignadoRepository.BeginTransaction();
            try
            {

                var mappedProductoAsignado = (await _ProductoAsignadoRepository.Get(updatedProductoAsignado.IdProductoAsignado)).FirstOrDefault();
		        var result = await _ProductoAsignadoRepository.Update(mappedProductoAsignado);
                var mappedResponse = _mapper.Map<ProductoAsignadoResponse>(result);
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
