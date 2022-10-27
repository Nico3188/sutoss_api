using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IenfermedadesService
    {
        public Task<List<enfermedadResponse>> GetAll(int? s, int? l, string q);
        public Task<enfermedadResponse> GetById(int id);
        public Task<enfermedadResponse> Create(enfermedadRequest newenfermedad, string userId);
        public Task<enfermedadResponse> Update(enfermedadRequest updatedenfermedad, string userId);
        public Task<bool> Delete(int id, string userId);
    }
}
