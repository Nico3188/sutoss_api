using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface Idetalle_facturasService
    {
        public Task<List<detalle_facturaResponse>> GetAll(int? s, int? l, string q);
        public Task<detalle_facturaResponse> GetById(int id);
        public Task<detalle_facturaResponse> Create(detalle_facturaRequest newdetalle_factura, string userId);
        public Task<detalle_facturaResponse> Update(detalle_facturaRequest updateddetalle_factura, string userId);
        public Task<bool> Delete(int id, string userId);
    }
}
