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
    public class FamiliarsService : BaseService, IFamiliarsService
    {
        private readonly IFamiliarRepository _FamiliarRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public FamiliarsService(
            IFamiliarRepository FamiliarRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _FamiliarRepository = FamiliarRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<FamiliarResponse> Create(FamiliarRequest newFamiliar )
        {
            var transaction = _FamiliarRepository.BeginTransaction();
            try
            {

                Familiar entity= _mapper.Map<Familiar>(newFamiliar);
                var addedFamiliar = await _FamiliarRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<FamiliarResponse>(addedFamiliar);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {
            var transaction = _FamiliarRepository.BeginTransaction();
            try
            {
                var result = (await _FamiliarRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Familiar not found");
                }
                await _FamiliarRepository.Delete(result.IdFamiliar);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

       

        public async Task<List<FamiliarResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<Familiar> items = await _FamiliarRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<FamiliarResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<FamiliarResponse> GetById(int id)
        {
            try
            {
                var result = (await _FamiliarRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Familiar not found");
                }
                return _mapper.Map<FamiliarResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<FamiliarResponse> Update(FamiliarRequest updatedFamiliar )
        {
            var transaction = _FamiliarRepository.BeginTransaction();
            try
            {
                var mappedFamiliar = (await _FamiliarRepository.Get(updatedFamiliar.IdFamiliar)).FirstOrDefault();
		        mappedFamiliar.IdFamiliar = updatedFamiliar.IdFamiliar;
                mappedFamiliar.FamDni = updatedFamiliar.FamDni;
                mappedFamiliar.FamNombre = updatedFamiliar.FamNombre;
                mappedFamiliar.FamDomicilio = updatedFamiliar.FamDomicilio;
                mappedFamiliar.Famnacimiento = updatedFamiliar.Famnacimiento;
                mappedFamiliar.PersonaIdPersona = updatedFamiliar.PersonaIdPersona;
                mappedFamiliar.FamVinculo = updatedFamiliar.FamVinculo;
                
                var result = await _FamiliarRepository.Update(mappedFamiliar);
                var mappedResponse = _mapper.Map<FamiliarResponse>(result);
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
