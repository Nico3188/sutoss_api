using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IPedidoProductosService
    {
        public Task<List<PedidoProductoResponse>> GetAll(int? s, int? l, string q);
        public Task<PedidoProductoResponse> GetById(int id);
        public Task<PedidoProductoResponse> Create(PedidoProductoRequest newPedidoProducto);
        public Task<PedidoProductoResponse> Update(PedidoProductoRequest updatedPedidoProducto);
        public Task<bool> Delete(int id);
    }
}
