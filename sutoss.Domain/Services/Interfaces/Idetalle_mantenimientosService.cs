using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface Idetalle_mantenimientosService
    {
        public Task<List<detalle_mantenimientoResponse>> GetAll(int? s, int? l, string q);
        public Task<detalle_mantenimientoResponse> GetById(int id);
        public Task<detalle_mantenimientoResponse> Create(detalle_mantenimientoRequest newdetalle_mantenimiento, string userId);
        public Task<detalle_mantenimientoResponse> Update(detalle_mantenimientoRequest updateddetalle_mantenimiento, string userId);
        public Task<bool> Delete(int id, string userId);
    }
}
