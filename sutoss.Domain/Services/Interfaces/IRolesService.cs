using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IRolesService
    {
        public Task<List<RoleResponse>> GetAll(int? s, int? l, string q);
        public Task<RoleResponse> GetById(int id);
        public Task<RoleResponse> Create(RoleRequest newRole);
        public Task<RoleResponse> Update(RoleRequest updatedRole);
        public Task<bool> Delete(int id);
    }
}
