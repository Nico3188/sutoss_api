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
    public class GanadorsService : BaseService, IGanadorsService
    {
        private readonly IGanadorRepository _GanadorRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public GanadorsService(
            IGanadorRepository GanadorRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _GanadorRepository = GanadorRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<GanadorResponse> Create(GanadorRequest newGanador )
        {
            var transaction = _GanadorRepository.BeginTransaction();
            try
            {

                Ganador entity= _mapper.Map<Ganador>(newGanador);
                var addedGanador = await _GanadorRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<GanadorResponse>(addedGanador);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {
            var transaction = _GanadorRepository.BeginTransaction();
            try
            {
                var result = (await _GanadorRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Ganador not found");
                }
                await _GanadorRepository.Delete(result.IdGanador);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<GanadorResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<Ganador> items = await _GanadorRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<GanadorResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GanadorResponse> GetById(int id)
        {
            try
            {
                var result = (await _GanadorRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Ganador not found");
                }
                return _mapper.Map<GanadorResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GanadorResponse> Update(GanadorRequest updatedGanador )
        {
            var transaction = _GanadorRepository.BeginTransaction();
            try
            {

                var mappedGanador = (await _GanadorRepository.Get(updatedGanador.IdGanador)).FirstOrDefault();
		        var result = await _GanadorRepository.Update(mappedGanador);
                var mappedResponse = _mapper.Map<GanadorResponse>(result);
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
