using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IgastosService
    {
        public Task<List<gastoResponse>> GetAll(int? s, int? l, string q);
        public Task<gastoResponse> GetById(int id);
        public Task<gastoResponse> Create(gastoRequest newgasto, string userId);
        public Task<gastoResponse> Update(gastoRequest updatedgasto, string userId);
        public Task<bool> Delete(int id, string userId);
    }
}
