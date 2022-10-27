using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IpremiosService
    {
        public Task<List<premioResponse>> GetAll(int? s, int? l, string q);
        public Task<premioResponse> GetById(int id);
        public Task<premioResponse> Create(premioRequest newpremio, string userId);
        public Task<premioResponse> Update(premioRequest updatedpremio, string userId);
        public Task<bool> Delete(int id, string userId);
    }
}
