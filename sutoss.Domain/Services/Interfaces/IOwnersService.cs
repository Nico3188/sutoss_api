using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IOwnersService
    {
        public Task<List<OwnerResponse>> GetAll(int? s, int? l, string q);
        public Task<OwnerResponse> GetById(int id);
        public Task<OwnerResponse> Create(OwnerRequest newOwner);
        public Task<OwnerResponse> Update(OwnerRequest updatedOwner);
        public Task<bool> Delete(int id);
        public Task<OwnerResponse> Profile(string userEmail);
    }
}
