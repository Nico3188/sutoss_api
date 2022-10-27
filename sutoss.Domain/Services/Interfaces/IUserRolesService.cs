using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IUserRolesService
    {
        public Task<List<UserRoleResponse>> GetAll(int? s, int? l, string q);
        public Task<UserRoleResponse> GetById(int id);
        public Task<UserRoleResponse> Create(UserRoleRequest newUserRole);
        public Task<UserRoleResponse> Update(UserRoleRequest updatedUserRole);
        public Task<bool> Delete(int id);
    }
}
