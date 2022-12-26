using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IProductoAsignadosService
    {
        public Task<List<ProductoAsignadoResponse>> GetAll(int? s, int? l, string q);
        public Task<ProductoAsignadoResponse> GetById(int id);
        public Task<ProductoAsignadoResponse> Create(ProductoAsignadoRequest newProductoAsignado);
        public Task<ProductoAsignadoResponse> Update(ProductoAsignadoRequest updatedProductoAsignado);
        public Task<bool> Delete(int id);
    }
}
