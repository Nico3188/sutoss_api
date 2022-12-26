using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IEventosService
    {
        public Task<List<EventoResponse>> GetAll(int? s, int? l, string q);
        public Task<EventoResponse> GetById(int id);
        public Task<EventoResponse> Create(EventoRequest newEvento);
        public Task<EventoResponse> Update(EventoRequest updatedEvento);
        public Task<bool> Delete(int id);
    }
}
