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
    public class suscripcionesService : BaseService, IsuscripcionesService
    {
        private readonly IsuscripcionRepository _suscripcionRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public suscripcionesService(
            IsuscripcionRepository suscripcionRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _suscripcionRepository = suscripcionRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<suscripcionResponse> Create(suscripcionRequest newsuscripcion, string externalUserId)
        {
            var transaction = _suscripcionRepository.BeginTransaction();
            try
            {

                suscripcion entity= _mapper.Map<suscripcion>(newsuscripcion);
                var addedsuscripcion = await _suscripcionRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<suscripcionResponse>(addedsuscripcion);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id, string externalUserId)
        {
            var transaction = _suscripcionRepository.BeginTransaction();
            try
            {
                var result = (await _suscripcionRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "suscripcion not found");
                }
                await _suscripcionRepository.Delete(result.suscripcionId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<suscripcionResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<suscripcion> items = await _suscripcionRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<suscripcionResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<suscripcionResponse> GetById(int id)
        {
            try
            {
                var result = (await _suscripcionRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "suscripcion not found");
                }
                return _mapper.Map<suscripcionResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<suscripcionResponse> Update(suscripcionRequest updatedsuscripcion, string externalUserId)
        {
            var transaction = _suscripcionRepository.BeginTransaction();
            try
            {

                var mappedsuscripcion = (await _suscripcionRepository.Get(updatedsuscripcion.suscripcionId)).FirstOrDefault();
		        var result = await _suscripcionRepository.Update(mappedsuscripcion);
                var mappedResponse = _mapper.Map<suscripcionResponse>(result);
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
