using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IDetalleComprasService
    {
        public Task<List<DetalleCompraResponse>> GetAll(int? s, int? l, string q);
        public Task<DetalleCompraResponse> GetById(int id);
        public Task<DetalleCompraResponse> Create(DetalleCompraRequest newDetalleCompra);
        public Task<DetalleCompraResponse> Update(DetalleCompraRequest updatedDetalleCompra);
        public Task<bool> Delete(int id);
    }
}
