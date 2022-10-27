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
    public class ganadoresService : BaseService, IganadoresService
    {
        private readonly IganadorRepository _ganadorRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public ganadoresService(
            IganadorRepository ganadorRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _ganadorRepository = ganadorRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<ganadorResponse> Create(ganadorRequest newganador, string externalUserId)
        {
            var transaction = _ganadorRepository.BeginTransaction();
            try
            {

                ganador entity= _mapper.Map<ganador>(newganador);
                var addedganador = await _ganadorRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<ganadorResponse>(addedganador);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id, string externalUserId)
        {
            var transaction = _ganadorRepository.BeginTransaction();
            try
            {
                var result = (await _ganadorRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "ganador not found");
                }
                await _ganadorRepository.Delete(result.ganadorId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<ganadorResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<ganador> items = await _ganadorRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<ganadorResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ganadorResponse> GetById(int id)
        {
            try
            {
                var result = (await _ganadorRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "ganador not found");
                }
                return _mapper.Map<ganadorResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ganadorResponse> Update(ganadorRequest updatedganador, string externalUserId)
        {
            var transaction = _ganadorRepository.BeginTransaction();
            try
            {

                var mappedganador = (await _ganadorRepository.Get(updatedganador.ganadorId)).FirstOrDefault();
		        var result = await _ganadorRepository.Update(mappedganador);
                var mappedResponse = _mapper.Map<ganadorResponse>(result);
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
