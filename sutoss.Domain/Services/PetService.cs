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
    public class PetsService : BaseService, IPetsService
    {
        private readonly IPetRepository _PetRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public PetsService(
            IPetRepository PetRepository,
            IUserRepository userRepository,
            IUserRoleRepository userRoleRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _PetRepository = PetRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<PetResponse> Create(PetRequest newPet)
        {
            var transaction = _PetRepository.BeginTransaction();
            try
            {

                Pet entity= _mapper.Map<Pet>(newPet);
                var addedPet = await _PetRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<PetResponse>(addedPet);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var transaction = _PetRepository.BeginTransaction();
            try
            {
                var result = (await _PetRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Pet not found");
                }
                await _PetRepository.Delete(result.PetId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<PetResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<Pet> items = await _PetRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<PetResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PetResponse> GetById(int id)
        {
            try
            {
                var result = (await _PetRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Pet not found");
                }
                return _mapper.Map<PetResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PetResponse> Update(PetRequest updatedPet)
        {
            var transaction = _PetRepository.BeginTransaction();
            try
            {

                var mappedPet = (await _PetRepository.Get(updatedPet.PetId)).FirstOrDefault();
		        var result = await _PetRepository.Update(mappedPet);
                var mappedResponse = _mapper.Map<PetResponse>(result);
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
