using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface ITurnosService
    {
        public Task<List<TurnoResponse>> GetAll(int? s, int? l, string q);
        public Task<TurnoResponse> GetById(int id);
        public Task<TurnoResponse> Create(TurnoRequest newTurno);
        public Task<TurnoResponse> Update(TurnoRequest updatedTurno);
        public Task<bool> Delete(int id);
    }
}
