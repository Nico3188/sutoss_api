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
    public class eventosService : BaseService, IeventosService
    {
        private readonly IeventoRepository _eventoRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public eventosService(
            IeventoRepository eventoRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _eventoRepository = eventoRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<eventoResponse> Create(eventoRequest newevento, string externalUserId)
        {
            var transaction = _eventoRepository.BeginTransaction();
            try
            {

                evento entity= _mapper.Map<evento>(newevento);
                var addedevento = await _eventoRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<eventoResponse>(addedevento);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id, string externalUserId)
        {
            var transaction = _eventoRepository.BeginTransaction();
            try
            {
                var result = (await _eventoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "evento not found");
                }
                await _eventoRepository.Delete(result.eventoId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<eventoResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<evento> items = await _eventoRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<eventoResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<eventoResponse> GetById(int id)
        {
            try
            {
                var result = (await _eventoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "evento not found");
                }
                return _mapper.Map<eventoResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<eventoResponse> Update(eventoRequest updatedevento, string externalUserId)
        {
            var transaction = _eventoRepository.BeginTransaction();
            try
            {

                var mappedevento = (await _eventoRepository.Get(updatedevento.eventoId)).FirstOrDefault();
		        var result = await _eventoRepository.Update(mappedevento);
                var mappedResponse = _mapper.Map<eventoResponse>(result);
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
