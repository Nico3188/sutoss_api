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
    public class personasService : BaseService, IpersonasService
    {
        private readonly IpersonaRepository _personaRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public personasService(
            IpersonaRepository personaRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _personaRepository = personaRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<personaResponse> Create(personaRequest newpersona, string externalUserId)
        {
            var transaction = _personaRepository.BeginTransaction();
            try
            {

                persona entity= _mapper.Map<persona>(newpersona);
                var addedpersona = await _personaRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<personaResponse>(addedpersona);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id, string externalUserId)
        {
            var transaction = _personaRepository.BeginTransaction();
            try
            {
                var result = (await _personaRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "persona not found");
                }
                await _personaRepository.Delete(result.personaId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<personaResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<persona> items = await _personaRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<personaResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<personaResponse> GetById(int id)
        {
            try
            {
                var result = (await _personaRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "persona not found");
                }
                return _mapper.Map<personaResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<personaResponse> Update(personaRequest updatedpersona, string externalUserId)
        {
            var transaction = _personaRepository.BeginTransaction();
            try
            {

                var mappedpersona = (await _personaRepository.Get(updatedpersona.personaId)).FirstOrDefault();
		        var result = await _personaRepository.Update(mappedpersona);
                var mappedResponse = _mapper.Map<personaResponse>(result);
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
