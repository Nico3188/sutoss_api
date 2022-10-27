using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IalquileresService
    {
        public Task<List<alquilerResponse>> GetAll(int? s, int? l, string q);
        public Task<alquilerResponse> GetById(int id);
        public Task<alquilerResponse> Create(alquilerRequest newalquiler, string userId);
        public Task<alquilerResponse> Update(alquilerRequest updatedalquiler, string userId);
        public Task<bool> Delete(int id, string userId);
    }
}
