using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IProductosService
    {
        public Task<List<ProductoResponse>> GetAll(int? s, int? l, string q);
        public Task<ProductoResponse> GetById(int id);
        public Task<ProductoResponse> Create(ProductoRequest newProducto);
        public Task<ProductoResponse> Update(ProductoRequest updatedProducto);
        public Task<bool> Delete(int id);
    }
}
