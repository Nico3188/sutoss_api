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
    public class productos_asignadosService : BaseService, Iproductos_asignadosService
    {
        private readonly Iproducto_asignadoRepository _producto_asignadoRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public productos_asignadosService(
            Iproducto_asignadoRepository producto_asignadoRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _producto_asignadoRepository = producto_asignadoRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<producto_asignadoResponse> Create(producto_asignadoRequest newproducto_asignado, string externalUserId)
        {
            var transaction = _producto_asignadoRepository.BeginTransaction();
            try
            {

                producto_asignado entity= _mapper.Map<producto_asignado>(newproducto_asignado);
                var addedproducto_asignado = await _producto_asignadoRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<producto_asignadoResponse>(addedproducto_asignado);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id, string externalUserId)
        {
            var transaction = _producto_asignadoRepository.BeginTransaction();
            try
            {
                var result = (await _producto_asignadoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "producto_asignado not found");
                }
                await _producto_asignadoRepository.Delete(result.producto_asignadoId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<producto_asignadoResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<producto_asignado> items = await _producto_asignadoRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<producto_asignadoResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<producto_asignadoResponse> GetById(int id)
        {
            try
            {
                var result = (await _producto_asignadoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "producto_asignado not found");
                }
                return _mapper.Map<producto_asignadoResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<producto_asignadoResponse> Update(producto_asignadoRequest updatedproducto_asignado, string externalUserId)
        {
            var transaction = _producto_asignadoRepository.BeginTransaction();
            try
            {

                var mappedproducto_asignado = (await _producto_asignadoRepository.Get(updatedproducto_asignado.producto_asignadoId)).FirstOrDefault();
		        var result = await _producto_asignadoRepository.Update(mappedproducto_asignado);
                var mappedResponse = _mapper.Map<producto_asignadoResponse>(result);
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
