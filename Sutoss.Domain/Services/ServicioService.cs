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
    public class ServiciosService : BaseService, IServiciosService
    {
        private readonly IServicioRepository _ServicioRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public ServiciosService(
            IServicioRepository ServicioRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _ServicioRepository = ServicioRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<ServicioResponse> Create(ServicioRequest newServicio )
        {
            var transaction = _ServicioRepository.BeginTransaction();
            try
            {

                Servicio entity= _mapper.Map<Servicio>(newServicio);
                var addedServicio = await _ServicioRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<ServicioResponse>(addedServicio);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {
            var transaction = _ServicioRepository.BeginTransaction();
            try
            {
                var result = (await _ServicioRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Servicio not found");
                }
                await _ServicioRepository.Delete(result.IdServicio);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<ServicioResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<Servicio> items = await _ServicioRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<ServicioResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ServicioResponse> GetById(int id)
        {
            try
            {
                var result = (await _ServicioRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Servicio not found");
                }
                return _mapper.Map<ServicioResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ServicioResponse> Update(ServicioRequest updatedServicio )
        {
            var transaction = _ServicioRepository.BeginTransaction();
            try
            {

                var mappedServicio = (await _ServicioRepository.Get(updatedServicio.IdServicio)).FirstOrDefault();
		        var result = await _ServicioRepository.Update(mappedServicio);
                var mappedResponse = _mapper.Map<ServicioResponse>(result);
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
