using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IMantenimientosService
    {
        public Task<List<MantenimientoResponse>> GetAll(int? s, int? l, string q);
        public Task<MantenimientoResponse> GetById(int id);
        public Task<MantenimientoResponse> Create(MantenimientoRequest newMantenimiento);
        public Task<MantenimientoResponse> Update(MantenimientoRequest updatedMantenimiento);
        public Task<bool> Delete(int id);
    }
}
