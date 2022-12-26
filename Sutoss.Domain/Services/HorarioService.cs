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
    public class HorariosService : BaseService, IHorariosService
    {
        private readonly IHorarioRepository _HorarioRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public HorariosService(
            IHorarioRepository HorarioRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _HorarioRepository = HorarioRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<HorarioResponse> Create(HorarioRequest newHorario )
        {
            var transaction = _HorarioRepository.BeginTransaction();
            try
            {

                Horario entity= _mapper.Map<Horario>(newHorario);
                var addedHorario = await _HorarioRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<HorarioResponse>(addedHorario);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {
            var transaction = _HorarioRepository.BeginTransaction();
            try
            {
                var result = (await _HorarioRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Horario not found");
                }
                await _HorarioRepository.Delete(result.IdHorario);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<HorarioResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<Horario> items = await _HorarioRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<HorarioResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<HorarioResponse> GetById(int id)
        {
            try
            {
                var result = (await _HorarioRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Horario not found");
                }
                return _mapper.Map<HorarioResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<HorarioResponse> Update(HorarioRequest updatedHorario )
        {
            var transaction = _HorarioRepository.BeginTransaction();
            try
            {

                var mappedHorario = (await _HorarioRepository.Get(updatedHorario.IdHorario)).FirstOrDefault();
		        var result = await _HorarioRepository.Update(mappedHorario);
                var mappedResponse = _mapper.Map<HorarioResponse>(result);
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
