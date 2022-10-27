using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IproveedoresService
    {
        public Task<List<proveedorResponse>> GetAll(int? s, int? l, string q);
        public Task<proveedorResponse> GetById(int id);
        public Task<proveedorResponse> Create(proveedorRequest newproveedor, string userId);
        public Task<proveedorResponse> Update(proveedorRequest updatedproveedor, string userId);
        public Task<bool> Delete(int id, string userId);
    }
}
