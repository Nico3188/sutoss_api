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
    public class horariosService : BaseService, IhorariosService
    {
        private readonly IhorarioRepository _horarioRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public horariosService(
            IhorarioRepository horarioRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _horarioRepository = horarioRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<horarioResponse> Create(horarioRequest newhorario, string externalUserId)
        {
            var transaction = _horarioRepository.BeginTransaction();
            try
            {

                horario entity= _mapper.Map<horario>(newhorario);
                var addedhorario = await _horarioRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<horarioResponse>(addedhorario);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id, string externalUserId)
        {
            var transaction = _horarioRepository.BeginTransaction();
            try
            {
                var result = (await _horarioRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "horario not found");
                }
                await _horarioRepository.Delete(result.horarioId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<horarioResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<horario> items = await _horarioRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<horarioResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<horarioResponse> GetById(int id)
        {
            try
            {
                var result = (await _horarioRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "horario not found");
                }
                return _mapper.Map<horarioResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<horarioResponse> Update(horarioRequest updatedhorario, string externalUserId)
        {
            var transaction = _horarioRepository.BeginTransaction();
            try
            {

                var mappedhorario = (await _horarioRepository.Get(updatedhorario.horarioId)).FirstOrDefault();
		        var result = await _horarioRepository.Update(mappedhorario);
                var mappedResponse = _mapper.Map<horarioResponse>(result);
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
