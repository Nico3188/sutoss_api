using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IprovinciasService
    {
        public Task<List<provinciaResponse>> GetAll(int? s, int? l, string q);
        public Task<provinciaResponse> GetById(int id);
        public Task<provinciaResponse> Create(provinciaRequest newprovincia, string userId);
        public Task<provinciaResponse> Update(provinciaRequest updatedprovincia, string userId);
        public Task<bool> Delete(int id, string userId);
    }
}
