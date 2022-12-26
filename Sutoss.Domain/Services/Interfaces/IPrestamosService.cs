using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IPrestamosService
    {
        public Task<List<PrestamoResponse>> GetAll(int? s, int? l, string q);
        public Task<PrestamoResponse> GetById(int id);
        public Task<PrestamoResponse> Create(PrestamoRequest newPrestamo);
        public Task<PrestamoResponse> Update(PrestamoRequest updatedPrestamo);
        public Task<bool> Delete(int id);
    }
}
