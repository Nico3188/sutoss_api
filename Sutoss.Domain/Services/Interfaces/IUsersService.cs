using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IUsersService
    {
        public Task<List<UserResponse>> GetAll(int? s, int? l, string q);
        public Task<UserResponse> GetById(int id);
        public Task<UserResponse> Create(UserRequest newUser);
        public Task<UserResponse> Update(UserRequest updatedUser);
        public Task<bool> Delete(int id);
    }
}
