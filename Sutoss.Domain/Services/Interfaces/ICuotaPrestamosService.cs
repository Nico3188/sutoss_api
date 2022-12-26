using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface ICuotaPrestamosService
    {
        public Task<List<CuotaPrestamoResponse>> GetAll(int? s, int? l, string q);
        public Task<CuotaPrestamoResponse> GetById(int id);
        public Task<CuotaPrestamoResponse> Create(CuotaPrestamoRequest newCuotaPrestamo);
        public Task<CuotaPrestamoResponse> Update(CuotaPrestamoRequest updatedCuotaPrestamo);
        public Task<bool> Delete(int id);
    }
}
