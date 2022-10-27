using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface Ipedidos_productosService
    {
        public Task<List<pedido_productoResponse>> GetAll(int? s, int? l, string q);
        public Task<pedido_productoResponse> GetById(int id);
        public Task<pedido_productoResponse> Create(pedido_productoRequest newpedido_producto, string userId);
        public Task<pedido_productoResponse> Update(pedido_productoRequest updatedpedido_producto, string userId);
        public Task<bool> Delete(int id, string userId);
    }
}
