using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IconveniosxprovService
    {
        public Task<List<convenioxprovResponse>> GetAll(int? s, int? l, string q);
        public Task<convenioxprovResponse> GetById(int id);
        public Task<convenioxprovResponse> Create(convenioxprovRequest newconvenioxprov, string userId);
        public Task<convenioxprovResponse> Update(convenioxprovRequest updatedconvenioxprov, string userId);
        public Task<bool> Delete(int id, string userId);
    }
}
