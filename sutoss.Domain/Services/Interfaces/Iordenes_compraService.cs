using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface Iordenes_compraService
    {
        public Task<List<orden_compraResponse>> GetAll(int? s, int? l, string q);
        public Task<orden_compraResponse> GetById(int id);
        public Task<orden_compraResponse> Create(orden_compraRequest neworden_compra, string userId);
        public Task<orden_compraResponse> Update(orden_compraRequest updatedorden_compra, string userId);
        public Task<bool> Delete(int id, string userId);
    }
}
