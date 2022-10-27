using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IfacturasService
    {
        public Task<List<facturaResponse>> GetAll(int? s, int? l, string q);
        public Task<facturaResponse> GetById(int id);
        public Task<facturaResponse> Create(facturaRequest newfactura, string userId);
        public Task<facturaResponse> Update(facturaRequest updatedfactura, string userId);
        public Task<bool> Delete(int id, string userId);
    }
}
