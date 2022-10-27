using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface ImantenimientosService
    {
        public Task<List<mantenimientoResponse>> GetAll(int? s, int? l, string q);
        public Task<mantenimientoResponse> GetById(int id);
        public Task<mantenimientoResponse> Create(mantenimientoRequest newmantenimiento, string userId);
        public Task<mantenimientoResponse> Update(mantenimientoRequest updatedmantenimiento, string userId);
        public Task<bool> Delete(int id, string userId);
    }
}
