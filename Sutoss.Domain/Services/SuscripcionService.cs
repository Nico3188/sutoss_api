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
    public class SuscripcionsService : BaseService, ISuscripcionsService
    {
        private readonly ISuscripcionRepository _SuscripcionRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public SuscripcionsService(
            ISuscripcionRepository SuscripcionRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _SuscripcionRepository = SuscripcionRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<SuscripcionResponse> Create(SuscripcionRequest newSuscripcion )
        {
            var transaction = _SuscripcionRepository.BeginTransaction();
            try
            {

                Suscripcion entity= _mapper.Map<Suscripcion>(newSuscripcion);
                var addedSuscripcion = await _SuscripcionRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<SuscripcionResponse>(addedSuscripcion);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {
            var transaction = _SuscripcionRepository.BeginTransaction();
            try
            {
                var result = (await _SuscripcionRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Suscripcion not found");
                }
                await _SuscripcionRepository.Delete(result.IdSuscripcion);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<SuscripcionResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<Suscripcion> items = await _SuscripcionRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<SuscripcionResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<SuscripcionResponse> GetById(int id)
        {
            try
            {
                var result = (await _SuscripcionRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Suscripcion not found");
                }
                return _mapper.Map<SuscripcionResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<SuscripcionResponse> Update(SuscripcionRequest updatedSuscripcion )
        {
            var transaction = _SuscripcionRepository.BeginTransaction();
            try
            {

                var mappedSuscripcion = (await _SuscripcionRepository.Get(updatedSuscripcion.IdSuscripcion)).FirstOrDefault();
		        var result = await _SuscripcionRepository.Update(mappedSuscripcion);
                var mappedResponse = _mapper.Map<SuscripcionResponse>(result);
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
