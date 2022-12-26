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
    public class EventosService : BaseService, IEventosService
    {
        private readonly IEventoRepository _EventoRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public EventosService(
            IEventoRepository EventoRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _EventoRepository = EventoRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<EventoResponse> Create(EventoRequest newEvento )
        {
            var transaction = _EventoRepository.BeginTransaction();
            try
            {

                Evento entity= _mapper.Map<Evento>(newEvento);
                var addedEvento = await _EventoRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<EventoResponse>(addedEvento);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {
            var transaction = _EventoRepository.BeginTransaction();
            try
            {
                var result = (await _EventoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Evento not found");
                }
                await _EventoRepository.Delete(result.IdEvento);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<EventoResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<Evento> items = await _EventoRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<EventoResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<EventoResponse> GetById(int id)
        {
            try
            {
                var result = (await _EventoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Evento not found");
                }
                return _mapper.Map<EventoResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<EventoResponse> Update(EventoRequest updatedEvento )
        {
            var transaction = _EventoRepository.BeginTransaction();
            try
            {

                var mappedEvento = (await _EventoRepository.Get(updatedEvento.IdEvento)).FirstOrDefault();
		        var result = await _EventoRepository.Update(mappedEvento);
                var mappedResponse = _mapper.Map<EventoResponse>(result);
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
