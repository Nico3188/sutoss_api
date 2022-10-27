using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IhorariosService
    {
        public Task<List<horarioResponse>> GetAll(int? s, int? l, string q);
        public Task<horarioResponse> GetById(int id);
        public Task<horarioResponse> Create(horarioRequest newhorario, string userId);
        public Task<horarioResponse> Update(horarioRequest updatedhorario, string userId);
        public Task<bool> Delete(int id, string userId);
    }
}
