using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IConocimientosService
    {
        public Task<List<ConocimientoResponse>> GetAll(int? s, int? l, string q);
        public Task<ConocimientoResponse> GetById(int id);
        public Task<ConocimientoResponse> Create(ConocimientoRequest newConocimiento);
        public Task<ConocimientoResponse> Update(ConocimientoRequest updatedConocimiento);
        public Task<bool> Delete(int id);
    }
}
