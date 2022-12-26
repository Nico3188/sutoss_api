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
    public class TurnosService : BaseService, ITurnosService
    {
        private readonly ITurnoRepository _TurnoRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public TurnosService(
            ITurnoRepository TurnoRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _TurnoRepository = TurnoRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<TurnoResponse> Create(TurnoRequest newTurno )
        {
            var transaction = _TurnoRepository.BeginTransaction();
            try
            {

                Turno entity= _mapper.Map<Turno>(newTurno);
                var addedTurno = await _TurnoRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<TurnoResponse>(addedTurno);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {
            var transaction = _TurnoRepository.BeginTransaction();
            try
            {
                var result = (await _TurnoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Turno not found");
                }
                await _TurnoRepository.Delete(result.IdTurno);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<TurnoResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<Turno> items = await _TurnoRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<TurnoResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TurnoResponse> GetById(int id)
        {
            try
            {
                var result = (await _TurnoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Turno not found");
                }
                return _mapper.Map<TurnoResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TurnoResponse> Update(TurnoRequest updatedTurno )
        {
            var transaction = _TurnoRepository.BeginTransaction();
            try
            {

                var mappedTurno = (await _TurnoRepository.Get(updatedTurno.IdTurno)).FirstOrDefault();
		        var result = await _TurnoRepository.Update(mappedTurno);
                var mappedResponse = _mapper.Map<TurnoResponse>(result);
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
