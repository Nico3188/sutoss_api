using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IanticiposService
    {
        public Task<List<anticipoResponse>> GetAll(int? s, int? l, string q);
        public Task<anticipoResponse> GetById(int id);
        public Task<anticipoResponse> Create(anticipoRequest newanticipo, string userId);
        public Task<anticipoResponse> Update(anticipoRequest updatedanticipo, string userId);
        public Task<bool> Delete(int id, string userId);
    }
}
