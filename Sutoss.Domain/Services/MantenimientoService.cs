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
    public class MantenimientosService : BaseService, IMantenimientosService
    {
        private readonly IMantenimientoRepository _MantenimientoRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public MantenimientosService(
            IMantenimientoRepository MantenimientoRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _MantenimientoRepository = MantenimientoRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<MantenimientoResponse> Create(MantenimientoRequest newMantenimiento )
        {
            var transaction = _MantenimientoRepository.BeginTransaction();
            try
            {

                Mantenimiento entity= _mapper.Map<Mantenimiento>(newMantenimiento);
                var addedMantenimiento = await _MantenimientoRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<MantenimientoResponse>(addedMantenimiento);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {
            var transaction = _MantenimientoRepository.BeginTransaction();
            try
            {
                var result = (await _MantenimientoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Mantenimiento not found");
                }
                await _MantenimientoRepository.Delete(result.IdMantenimiento);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<MantenimientoResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<Mantenimiento> items = await _MantenimientoRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<MantenimientoResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<MantenimientoResponse> GetById(int id)
        {
            try
            {
                var result = (await _MantenimientoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Mantenimiento not found");
                }
                return _mapper.Map<MantenimientoResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<MantenimientoResponse> Update(MantenimientoRequest updatedMantenimiento )
        {
            var transaction = _MantenimientoRepository.BeginTransaction();
            try
            {

                var mappedMantenimiento = (await _MantenimientoRepository.Get(updatedMantenimiento.IdMantenimiento)).FirstOrDefault();
		        var result = await _MantenimientoRepository.Update(mappedMantenimiento);
                var mappedResponse = _mapper.Map<MantenimientoResponse>(result);
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
