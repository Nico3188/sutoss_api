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
    public class mantenimientosService : BaseService, ImantenimientosService
    {
        private readonly ImantenimientoRepository _mantenimientoRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public mantenimientosService(
            ImantenimientoRepository mantenimientoRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _mantenimientoRepository = mantenimientoRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<mantenimientoResponse> Create(mantenimientoRequest newmantenimiento, string externalUserId)
        {
            var transaction = _mantenimientoRepository.BeginTransaction();
            try
            {

                mantenimiento entity= _mapper.Map<mantenimiento>(newmantenimiento);
                var addedmantenimiento = await _mantenimientoRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<mantenimientoResponse>(addedmantenimiento);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id, string externalUserId)
        {
            var transaction = _mantenimientoRepository.BeginTransaction();
            try
            {
                var result = (await _mantenimientoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "mantenimiento not found");
                }
                await _mantenimientoRepository.Delete(result.mantenimientoId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<mantenimientoResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<mantenimiento> items = await _mantenimientoRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<mantenimientoResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<mantenimientoResponse> GetById(int id)
        {
            try
            {
                var result = (await _mantenimientoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "mantenimiento not found");
                }
                return _mapper.Map<mantenimientoResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<mantenimientoResponse> Update(mantenimientoRequest updatedmantenimiento, string externalUserId)
        {
            var transaction = _mantenimientoRepository.BeginTransaction();
            try
            {

                var mappedmantenimiento = (await _mantenimientoRepository.Get(updatedmantenimiento.mantenimientoId)).FirstOrDefault();
		        var result = await _mantenimientoRepository.Update(mappedmantenimiento);
                var mappedResponse = _mapper.Map<mantenimientoResponse>(result);
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
