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
    public class UserRolesService : BaseService, IUserRolesService
    {
        private readonly IUserRoleRepository _UserRoleRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public UserRolesService(
            IUserRoleRepository UserRoleRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _UserRoleRepository = UserRoleRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<UserRoleResponse> Create(UserRoleRequest newUserRole)
        {
            var transaction = _UserRoleRepository.BeginTransaction();
            try
            {

                UserRole entity= _mapper.Map<UserRole>(newUserRole);
                var addedUserRole = await _UserRoleRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<UserRoleResponse>(addedUserRole);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var transaction = _UserRoleRepository.BeginTransaction();
            try
            {
                var result = (await _UserRoleRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "UserRole not found");
                }
                await _UserRoleRepository.Delete(result.UserRoleId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<UserRoleResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<UserRole> items = await _UserRoleRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<UserRoleResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UserRoleResponse> GetById(int id)
        {
            try
            {
                var result = (await _UserRoleRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "UserRole not found");
                }
                return _mapper.Map<UserRoleResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UserRoleResponse> Update(UserRoleRequest updatedUserRole)
        {
            var transaction = _UserRoleRepository.BeginTransaction();
            try
            {

                var mappedUserRole = (await _UserRoleRepository.Get(updatedUserRole.UserRoleId)).FirstOrDefault();
		        var result = await _UserRoleRepository.Update(mappedUserRole);
                var mappedResponse = _mapper.Map<UserRoleResponse>(result);
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
