using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IimpuestosService
    {
        public Task<List<impuestoResponse>> GetAll(int? s, int? l, string q);
        public Task<impuestoResponse> GetById(int id);
        public Task<impuestoResponse> Create(impuestoRequest newimpuesto, string userId);
        public Task<impuestoResponse> Update(impuestoRequest updatedimpuesto, string userId);
        public Task<bool> Delete(int id, string userId);
    }
}
