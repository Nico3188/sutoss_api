using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IConvenioxprovsService
    {
        public Task<List<ConvenioxprovResponse>> GetAll(int? s, int? l, string q);
        public Task<ConvenioxprovResponse> GetById(int id);
        public Task<ConvenioxprovResponse> Create(ConvenioxprovRequest newConvenioxprov);
        public Task<ConvenioxprovResponse> Update(ConvenioxprovRequest updatedConvenioxprov);
        public Task<bool> Delete(int id);
    }
}
