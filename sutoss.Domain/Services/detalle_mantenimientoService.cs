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
    public class detalle_mantenimientosService : BaseService, Idetalle_mantenimientosService
    {
        private readonly Idetalle_mantenimientoRepository _detalle_mantenimientoRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public detalle_mantenimientosService(
            Idetalle_mantenimientoRepository detalle_mantenimientoRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _detalle_mantenimientoRepository = detalle_mantenimientoRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<detalle_mantenimientoResponse> Create(detalle_mantenimientoRequest newdetalle_mantenimiento, string externalUserId)
        {
            var transaction = _detalle_mantenimientoRepository.BeginTransaction();
            try
            {

                detalle_mantenimiento entity= _mapper.Map<detalle_mantenimiento>(newdetalle_mantenimiento);
                var addeddetalle_mantenimiento = await _detalle_mantenimientoRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<detalle_mantenimientoResponse>(addeddetalle_mantenimiento);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id, string externalUserId)
        {
            var transaction = _detalle_mantenimientoRepository.BeginTransaction();
            try
            {
                var result = (await _detalle_mantenimientoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "detalle_mantenimiento not found");
                }
                await _detalle_mantenimientoRepository.Delete(result.detalle_mantenimientoId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<detalle_mantenimientoResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<detalle_mantenimiento> items = await _detalle_mantenimientoRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<detalle_mantenimientoResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<detalle_mantenimientoResponse> GetById(int id)
        {
            try
            {
                var result = (await _detalle_mantenimientoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "detalle_mantenimiento not found");
                }
                return _mapper.Map<detalle_mantenimientoResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<detalle_mantenimientoResponse> Update(detalle_mantenimientoRequest updateddetalle_mantenimiento, string externalUserId)
        {
            var transaction = _detalle_mantenimientoRepository.BeginTransaction();
            try
            {

                var mappeddetalle_mantenimiento = (await _detalle_mantenimientoRepository.Get(updateddetalle_mantenimiento.detalle_mantenimientoId)).FirstOrDefault();
		        var result = await _detalle_mantenimientoRepository.Update(mappeddetalle_mantenimiento);
                var mappedResponse = _mapper.Map<detalle_mantenimientoResponse>(result);
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
