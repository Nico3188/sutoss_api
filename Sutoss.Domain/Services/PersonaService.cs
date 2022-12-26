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
    public class PersonasService : BaseService, IPersonasService
    {
        private readonly IPersonaRepository _PersonaRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public PersonasService(
            IPersonaRepository PersonaRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _PersonaRepository = PersonaRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<PersonaResponse> Create(PersonaRequest newPersona )
        {
            var transaction = _PersonaRepository.BeginTransaction();
            try
            {

                Persona entity= _mapper.Map<Persona>(newPersona);
                var addedPersona = await _PersonaRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<PersonaResponse>(addedPersona);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {
            var transaction = _PersonaRepository.BeginTransaction();
            try
            {
                var result = (await _PersonaRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Persona not found");
                }
                await _PersonaRepository.Delete(result.IdPersona);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<PersonaResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<Persona> items = await _PersonaRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<PersonaResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PersonaResponse> GetById(int id)
        {
            try
            {
                var result = (await _PersonaRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Persona not found");
                }
                return _mapper.Map<PersonaResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PersonaResponse> Update(PersonaRequest updatedPersona )
        {
            var transaction = _PersonaRepository.BeginTransaction();
            try
            {

                var mappedPersona = (await _PersonaRepository.Get(updatedPersona.IdPersona)).FirstOrDefault();
		        var result = await _PersonaRepository.Update(mappedPersona);
                var mappedResponse = _mapper.Map<PersonaResponse>(result);
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
