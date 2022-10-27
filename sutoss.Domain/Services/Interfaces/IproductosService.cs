using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IproductosService
    {
        public Task<List<productoResponse>> GetAll(int? s, int? l, string q);
        public Task<productoResponse> GetById(int id);
        public Task<productoResponse> Create(productoRequest newproducto, string userId);
        public Task<productoResponse> Update(productoRequest updatedproducto, string userId);
        public Task<bool> Delete(int id, string userId);
    }
}
