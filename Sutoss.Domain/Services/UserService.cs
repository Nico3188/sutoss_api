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
    public class UsersService : BaseService, IUsersService
    {
        private readonly IUserRepository _UserRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public UsersService(
            IUserRepository UserRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _UserRepository = UserRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<UserResponse> Create(UserRequest newUser )
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

        public async Task<bool> Delete(int id )
        {
            var transaction = _UserRepository.BeginTransaction();
            try
            {
                var result = (await _UserRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "User not found");
                }
                await _UserRepository.Delete(result.IdUser);
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

        public async Task<UserResponse> Update(UserRequest updatedUser )
        {
            var transaction = _UserRepository.BeginTransaction();
            try
            {

                var mappedUser = (await _UserRepository.Get(updatedUser.IdUser)).FirstOrDefault();
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
