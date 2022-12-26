using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IDetalleMantenimientosService
    {
        public Task<List<DetalleMantenimientoResponse>> GetAll(int? s, int? l, string q);
        public Task<DetalleMantenimientoResponse> GetById(int id);
        public Task<DetalleMantenimientoResponse> Create(DetalleMantenimientoRequest newDetalleMantenimiento);
        public Task<DetalleMantenimientoResponse> Update(DetalleMantenimientoRequest updatedDetalleMantenimiento);
        public Task<bool> Delete(int id);
    }
}
