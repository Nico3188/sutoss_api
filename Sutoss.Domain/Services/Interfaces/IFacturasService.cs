using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IFacturasService
    {
        public Task<List<FacturaResponse>> GetAll(int? s, int? l, string q);
        public Task<FacturaResponse> GetById(int id);
        public Task<FacturaResponse> Create(FacturaRequest newFactura);
        public Task<FacturaResponse> Update(FacturaRequest updatedFactura);
        public Task<bool> Delete(int id);
    }
}
