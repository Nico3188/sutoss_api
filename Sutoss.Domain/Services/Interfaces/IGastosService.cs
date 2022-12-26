using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IGastosService
    {
        public Task<List<GastoResponse>> GetAll(int? s, int? l, string q);
        public Task<GastoResponse> GetById(int id);
        public Task<GastoResponse> Create(GastoRequest newGasto);
        public Task<GastoResponse> Update(GastoRequest updatedGasto);
        public Task<bool> Delete(int id);
    }
}
