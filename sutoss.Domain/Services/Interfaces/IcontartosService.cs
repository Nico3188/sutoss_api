using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IcontartosService
    {
        public Task<List<contratoResponse>> GetAll(int? s, int? l, string q);
        public Task<contratoResponse> GetById(int id);
        public Task<contratoResponse> Create(contratoRequest newcontrato, string userId);
        public Task<contratoResponse> Update(contratoRequest updatedcontrato, string userId);
        public Task<bool> Delete(int id, string userId);
    }
}
