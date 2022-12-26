using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IOrdenPagosService
    {
        public Task<List<OrdenPagoResponse>> GetAll(int? s, int? l, string q);
        public Task<OrdenPagoResponse> GetById(int id);
        public Task<OrdenPagoResponse> Create(OrdenPagoRequest newOrdenPago);
        public Task<OrdenPagoResponse> Update(OrdenPagoRequest updatedOrdenPago);
        public Task<bool> Delete(int id);
    }
}
