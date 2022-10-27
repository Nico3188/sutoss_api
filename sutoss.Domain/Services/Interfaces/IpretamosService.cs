using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IpretamosService
    {
        public Task<List<prestamoResponse>> GetAll(int? s, int? l, string q);
        public Task<prestamoResponse> GetById(int id);
        public Task<prestamoResponse> Create(prestamoRequest newprestamo, string userId);
        public Task<prestamoResponse> Update(prestamoRequest updatedprestamo, string userId);
        public Task<bool> Delete(int id, string userId);
    }
}
