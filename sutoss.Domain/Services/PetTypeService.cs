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
    public class PetTypesService : BaseService, IPetTypesService
    {
        private readonly IPetTypeRepository _PetTypeRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public PetTypesService(
            IPetTypeRepository PetTypeRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _PetTypeRepository = PetTypeRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<PetTypeResponse> Create(PetTypeRequest newPetType)
        {
            var transaction = _PetTypeRepository.BeginTransaction();
            try
            {

                PetType entity= _mapper.Map<PetType>(newPetType);
                var addedPetType = await _PetTypeRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<PetTypeResponse>(addedPetType);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var transaction = _PetTypeRepository.BeginTransaction();
            try
            {
                var result = (await _PetTypeRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "PetType not found");
                }
                await _PetTypeRepository.Delete(result.PetTypeId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<PetTypeResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<PetType> items = await _PetTypeRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<PetTypeResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PetTypeResponse> GetById(int id)
        {
            try
            {
                var result = (await _PetTypeRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "PetType not found");
                }
                return _mapper.Map<PetTypeResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PetTypeResponse> Update(PetTypeRequest updatedPetType)
        {
            var transaction = _PetTypeRepository.BeginTransaction();
            try
            {

                var mappedPetType = (await _PetTypeRepository.Get(updatedPetType.PetTypeId)).FirstOrDefault();
		        var result = await _PetTypeRepository.Update(mappedPetType);
                var mappedResponse = _mapper.Map<PetTypeResponse>(result);
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
