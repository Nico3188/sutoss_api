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
    public class DetalleComprasService : BaseService, IDetalleComprasService
    {
        private readonly IDetalleCompraRepository _DetalleCompraRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public DetalleComprasService(
            IDetalleCompraRepository DetalleCompraRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _DetalleCompraRepository = DetalleCompraRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<DetalleCompraResponse> Create(DetalleCompraRequest newDetalleCompra )
        {
            var transaction = _DetalleCompraRepository.BeginTransaction();
            try
            {

                DetalleCompra entity= _mapper.Map<DetalleCompra>(newDetalleCompra);
                var addedDetalleCompra = await _DetalleCompraRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<DetalleCompraResponse>(addedDetalleCompra);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {
            var transaction = _DetalleCompraRepository.BeginTransaction();
            try
            {
                var result = (await _DetalleCompraRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "DetalleCompra not found");
                }
                await _DetalleCompraRepository.Delete(result.IdDetalleCompra);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<DetalleCompraResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<DetalleCompra> items = await _DetalleCompraRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<DetalleCompraResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DetalleCompraResponse> GetById(int id)
        {
            try
            {
                var result = (await _DetalleCompraRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "DetalleCompra not found");
                }
                return _mapper.Map<DetalleCompraResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DetalleCompraResponse> Update(DetalleCompraRequest updatedDetalleCompra )
        {
            var transaction = _DetalleCompraRepository.BeginTransaction();
            try
            {

                var mappedDetalleCompra = (await _DetalleCompraRepository.Get(updatedDetalleCompra.IdDetalleCompra)).FirstOrDefault();
		        var result = await _DetalleCompraRepository.Update(mappedDetalleCompra);
                var mappedResponse = _mapper.Map<DetalleCompraResponse>(result);
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
