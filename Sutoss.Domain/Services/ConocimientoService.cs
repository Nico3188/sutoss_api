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
    public class ConocimientosService : BaseService, IConocimientosService
    {
        private readonly IConocimientoRepository _ConocimientoRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public ConocimientosService(
            IConocimientoRepository ConocimientoRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _ConocimientoRepository = ConocimientoRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<ConocimientoResponse> Create(ConocimientoRequest newConocimiento )
        {
            var transaction = _ConocimientoRepository.BeginTransaction();
            try
            {

                Conocimiento entity= _mapper.Map<Conocimiento>(newConocimiento);
                var addedConocimiento = await _ConocimientoRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<ConocimientoResponse>(addedConocimiento);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {
            var transaction = _ConocimientoRepository.BeginTransaction();
            try
            {
                var result = (await _ConocimientoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Conocimiento not found");
                }
                await _ConocimientoRepository.Delete(result.IdConocimiento);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<ConocimientoResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<Conocimiento> items = await _ConocimientoRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<ConocimientoResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ConocimientoResponse> GetById(int id)
        {
            try
            {
                var result = (await _ConocimientoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Conocimiento not found");
                }
                return _mapper.Map<ConocimientoResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ConocimientoResponse> Update(ConocimientoRequest updatedConocimiento )
        {
            var transaction = _ConocimientoRepository.BeginTransaction();
            try
            {

                var mappedConocimiento = (await _ConocimientoRepository.Get(updatedConocimiento.IdConocimiento)).FirstOrDefault();
		        var result = await _ConocimientoRepository.Update(mappedConocimiento);
                var mappedResponse = _mapper.Map<ConocimientoResponse>(result);
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
