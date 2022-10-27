using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface Iordenes_pagoService
    {
        public Task<List<orden_pagoResponse>> GetAll(int? s, int? l, string q);
        public Task<orden_pagoResponse> GetById(int id);
        public Task<orden_pagoResponse> Create(orden_pagoRequest neworden_pago, string userId);
        public Task<orden_pagoResponse> Update(orden_pagoRequest updatedorden_pago, string userId);
        public Task<bool> Delete(int id, string userId);
    }
}
