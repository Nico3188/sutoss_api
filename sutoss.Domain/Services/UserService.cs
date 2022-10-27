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
using sutoss.Domain.Services.Domain.Repositories;
using Microsoft.AspNetCore.Identity;

namespace sutoss.Domain.Services.Domain.Services
{
    public class UsersService : BaseService, IUsersService
    {
        private readonly IUserRepository _UserRepository;
        private readonly IOwnerRepository _ownerRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public UsersService(
            IUserRepository UserRepository,
            IOwnerRepository ownerRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _UserRepository = UserRepository;
            _ownerRepository = ownerRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<UserResponse> Create(UserRequest newUser)
        {
            var transaction = _UserRepository.BeginTransaction();
            try
            {

                User entity= _mapper.Map<User>(newUser);
                var addedUser = await _UserRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<UserResponse>(addedUser);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var transaction = _UserRepository.BeginTransaction();
            try
            {
                var result = (await _UserRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "User not found");
                }
                await _UserRepository.Delete(result.UserId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<UserResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<User> items = await _UserRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<UserResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UserResponse> GetById(int id)
        {
            try
            {
                var result = (await _UserRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "User not found");
                }
                return _mapper.Map<UserResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> RegisterClient(RegisterRequest registerRequest)
        {
            var transaction = _UserRepository.BeginTransaction();
            try
            {
                var owner = await _ownerRepository.Insert(new Owner
                {
                    Cbu = null,
                    Deleted = false,
                    FirstName = null,
                    LastName = null,
                    Birthdate = null,
                });
                
                var user = _UserRepository.Insert(
                    new User 
                    { 
                    Deleted = false, 
                    OwnerId = owner.OwnerId, 
                    Email = registerRequest.Email, 
                    }
                );
                transaction.Commit();
                return true;
            }
            catch(Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<UserResponse> Update(UserRequest updatedUser)
        {
            var transaction = _UserRepository.BeginTransaction();
            try
            {

                var mappedUser = (await _UserRepository.Get(updatedUser.UserId)).FirstOrDefault();
		        var result = await _UserRepository.Update(mappedUser);
                var mappedResponse = _mapper.Map<UserResponse>(result);
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
