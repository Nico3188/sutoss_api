using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IProveedorsService
    {
        public Task<List<ProveedorResponse>> GetAll(int? s, int? l, string q);
        public Task<ProveedorResponse> GetById(int id);
        public Task<ProveedorResponse> Create(ProveedorRequest newProveedor);
        public Task<ProveedorResponse> Update(ProveedorRequest updatedProveedor);
        public Task<bool> Delete(int id);
    }
}
