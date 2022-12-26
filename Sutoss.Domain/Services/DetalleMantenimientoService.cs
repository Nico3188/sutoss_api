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
    public class DetalleMantenimientosService : BaseService, IDetalleMantenimientosService
    {
        private readonly IDetalleMantenimientoRepository _DetalleMantenimientoRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public DetalleMantenimientosService(
            IDetalleMantenimientoRepository DetalleMantenimientoRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _DetalleMantenimientoRepository = DetalleMantenimientoRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<DetalleMantenimientoResponse> Create(DetalleMantenimientoRequest newDetalleMantenimiento )
        {
            var transaction = _DetalleMantenimientoRepository.BeginTransaction();
            try
            {

                DetalleMantenimiento entity= _mapper.Map<DetalleMantenimiento>(newDetalleMantenimiento);
                var addedDetalleMantenimiento = await _DetalleMantenimientoRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<DetalleMantenimientoResponse>(addedDetalleMantenimiento);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {
            var transaction = _DetalleMantenimientoRepository.BeginTransaction();
            try
            {
                var result = (await _DetalleMantenimientoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "DetalleMantenimiento not found");
                }
                await _DetalleMantenimientoRepository.Delete(result.IdDetalleMantenimiento);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<DetalleMantenimientoResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<DetalleMantenimiento> items = await _DetalleMantenimientoRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<DetalleMantenimientoResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DetalleMantenimientoResponse> GetById(int id)
        {
            try
            {
                var result = (await _DetalleMantenimientoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "DetalleMantenimiento not found");
                }
                return _mapper.Map<DetalleMantenimientoResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DetalleMantenimientoResponse> Update(DetalleMantenimientoRequest updatedDetalleMantenimiento )
        {
            var transaction = _DetalleMantenimientoRepository.BeginTransaction();
            try
            {

                var mappedDetalleMantenimiento = (await _DetalleMantenimientoRepository.Get(updatedDetalleMantenimiento.IdDetalleMantenimiento)).FirstOrDefault();
		        var result = await _DetalleMantenimientoRepository.Update(mappedDetalleMantenimiento);
                var mappedResponse = _mapper.Map<DetalleMantenimientoResponse>(result);
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
