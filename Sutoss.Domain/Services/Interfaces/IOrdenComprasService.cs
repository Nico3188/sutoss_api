using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IOrdenComprasService
    {
        public Task<List<OrdenCompraResponse>> GetAll(int? s, int? l, string q);
        public Task<OrdenCompraResponse> GetById(int id);
        public Task<OrdenCompraResponse> Create(OrdenCompraRequest newOrdenCompra);
        public Task<OrdenCompraResponse> Update(OrdenCompraRequest updatedOrdenCompra);
        public Task<bool> Delete(int id);
    }
}
