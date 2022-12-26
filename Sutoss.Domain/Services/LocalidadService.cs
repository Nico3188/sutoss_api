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
    public class LocalidadsService : BaseService, ILocalidadsService
    {
        private readonly ILocalidadRepository _LocalidadRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public LocalidadsService(
            ILocalidadRepository LocalidadRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _LocalidadRepository = LocalidadRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<LocalidadResponse> Create(LocalidadRequest newLocalidad )
        {
            var transaction = _LocalidadRepository.BeginTransaction();
            try
            {

                Localidad entity= _mapper.Map<Localidad>(newLocalidad);
                var addedLocalidad = await _LocalidadRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<LocalidadResponse>(addedLocalidad);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {
            var transaction = _LocalidadRepository.BeginTransaction();
            try
            {
                var result = (await _LocalidadRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Localidad not found");
                }
                await _LocalidadRepository.Delete(result.IdLocalidad);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<LocalidadResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<Localidad> items = await _LocalidadRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<LocalidadResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<LocalidadResponse> GetById(int id)
        {
            try
            {
                var result = (await _LocalidadRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Localidad not found");
                }
                return _mapper.Map<LocalidadResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<LocalidadResponse> Update(LocalidadRequest updatedLocalidad )
        {
            var transaction = _LocalidadRepository.BeginTransaction();
            try
            {

                var mappedLocalidad = (await _LocalidadRepository.Get(updatedLocalidad.IdLocalidad)).FirstOrDefault();
		        var result = await _LocalidadRepository.Update(mappedLocalidad);
                var mappedResponse = _mapper.Map<LocalidadResponse>(result);
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
