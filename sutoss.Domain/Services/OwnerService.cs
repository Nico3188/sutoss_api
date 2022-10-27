using AutoMapper;
using sutoss.Domain.Services.Domain.Repositories.Interfaces;
using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using sutoss.Domain.Services.Domain.Services.Base;
using sutoss.Domain.Services.Domain.Services.Interfaces;
using sutoss.Domain.Services.Exceptions;
using sutoss.Domain.Services.Helpers;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace sutoss.Domain.Services.Domain.Services
{
    public class OwnersService : BaseService, IOwnersService
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly IUserRepository _userRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public OwnersService(
            IOwnerRepository ownerRepository,
            IUserRepository userRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _ownerRepository = ownerRepository;
            _userRepository = userRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<OwnerResponse> Create(OwnerRequest newOwner)
        {
            var transaction = _ownerRepository.BeginTransaction();
            try
            {

                Owner entity= _mapper.Map<Owner>(newOwner);
                var addedOwner = await _ownerRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<OwnerResponse>(addedOwner);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var transaction = _ownerRepository.BeginTransaction();
            try
            {
                var result = (await _ownerRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Owner not found");
                }
                await _ownerRepository.Delete(result.OwnerId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<OwnerResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<Owner> items = await _ownerRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<OwnerResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<OwnerResponse> GetById(int id)
        {
            try
            {
                var result = (await _ownerRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Owner not found");
                }
                return _mapper.Map<OwnerResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<OwnerResponse> Update(OwnerRequest updatedOwner)
        {
            var transaction = _ownerRepository.BeginTransaction();
            try
            {
                var mappedOwner = (await _ownerRepository.Get(updatedOwner.OwnerId)).FirstOrDefault();
                mappedOwner.Birthdate = updatedOwner.Birthdate;
                mappedOwner.Cbu = updatedOwner.Cbu;
                mappedOwner.FirstName = updatedOwner.FirstName;
                mappedOwner.LastName = updatedOwner.LastName;
                var result = await _ownerRepository.Update(mappedOwner);
                var mappedResponse = _mapper.Map<OwnerResponse>(result);
                transaction.Commit();
                return mappedResponse;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<OwnerResponse> Profile(string userEmail)
        {
            try
            {
                var user = (await _userRepository.All()).Where(x => x.Email == userEmail).FirstOrDefault();
                if (user == null)
                    throw new NotFoundException("User not found");
                var owner = (await _ownerRepository.Get(user.OwnerId)).FirstOrDefault();
                var response = _mapper.Map<Owner, OwnerResponse>(owner);
                response.Email = userEmail;
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
