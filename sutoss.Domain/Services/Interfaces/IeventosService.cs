using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IeventosService
    {
        public Task<List<eventoResponse>> GetAll(int? s, int? l, string q);
        public Task<eventoResponse> GetById(int id);
        public Task<eventoResponse> Create(eventoRequest newevento, string userId);
        public Task<eventoResponse> Update(eventoRequest updatedevento, string userId);
        public Task<bool> Delete(int id, string userId);
    }
}
