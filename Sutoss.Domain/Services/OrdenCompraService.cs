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
    public class OrdenComprasService : BaseService, IOrdenComprasService
    {
        private readonly IOrdenCompraRepository _OrdenCompraRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public OrdenComprasService(
            IOrdenCompraRepository OrdenCompraRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _OrdenCompraRepository = OrdenCompraRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<OrdenCompraResponse> Create(OrdenCompraRequest newOrdenCompra )
        {
            var transaction = _OrdenCompraRepository.BeginTransaction();
            try
            {

                OrdenCompra entity= _mapper.Map<OrdenCompra>(newOrdenCompra);
                var addedOrdenCompra = await _OrdenCompraRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<OrdenCompraResponse>(addedOrdenCompra);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {
            var transaction = _OrdenCompraRepository.BeginTransaction();
            try
            {
                var result = (await _OrdenCompraRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "OrdenCompra not found");
                }
                await _OrdenCompraRepository.Delete(result.IdOrdenCompra);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<OrdenCompraResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<OrdenCompra> items = await _OrdenCompraRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<OrdenCompraResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<OrdenCompraResponse> GetById(int id)
        {
            try
            {
                var result = (await _OrdenCompraRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "OrdenCompra not found");
                }
                return _mapper.Map<OrdenCompraResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<OrdenCompraResponse> Update(OrdenCompraRequest updatedOrdenCompra )
        {
            var transaction = _OrdenCompraRepository.BeginTransaction();
            try
            {

                var mappedOrdenCompra = (await _OrdenCompraRepository.Get(updatedOrdenCompra.IdOrdenCompra)).FirstOrDefault();
		        var result = await _OrdenCompraRepository.Update(mappedOrdenCompra);
                var mappedResponse = _mapper.Map<OrdenCompraResponse>(result);
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
