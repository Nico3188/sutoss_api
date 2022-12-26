using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IDetalleFacturasService
    {
        public Task<List<DetalleFacturaResponse>> GetAll(int? s, int? l, string q);
        public Task<DetalleFacturaResponse> GetById(int id);
        public Task<DetalleFacturaResponse> Create(DetalleFacturaRequest newDetalleFactura);
        public Task<DetalleFacturaResponse> Update(DetalleFacturaRequest updatedDetalleFactura);
        public Task<bool> Delete(int id);
    }
}
