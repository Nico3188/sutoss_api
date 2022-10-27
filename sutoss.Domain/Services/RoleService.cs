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
    public class RolesService : BaseService, IRolesService
    {
        private readonly IRoleRepository _RoleRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public RolesService(
            IRoleRepository RoleRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _RoleRepository = RoleRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<RoleResponse> Create(RoleRequest newRole)
        {
            var transaction = _RoleRepository.BeginTransaction();
            try
            {

                Role entity= _mapper.Map<Role>(newRole);
                var addedRole = await _RoleRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<RoleResponse>(addedRole);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var transaction = _RoleRepository.BeginTransaction();
            try
            {
                var result = (await _RoleRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Role not found");
                }
                await _RoleRepository.Delete(result.RoleId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<RoleResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<Role> items = await _RoleRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<RoleResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<RoleResponse> GetById(int id)
        {
            try
            {
                var result = (await _RoleRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Role not found");
                }
                return _mapper.Map<RoleResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<RoleResponse> Update(RoleRequest updatedRole)
        {
            var transaction = _RoleRepository.BeginTransaction();
            try
            {

                var mappedRole = (await _RoleRepository.Get(updatedRole.RoleId)).FirstOrDefault();
		        var result = await _RoleRepository.Update(mappedRole);
                var mappedResponse = _mapper.Map<RoleResponse>(result);
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
