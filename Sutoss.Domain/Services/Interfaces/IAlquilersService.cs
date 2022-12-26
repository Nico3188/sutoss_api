using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IAlquilersService
    {
        public Task<List<AlquilerResponse>> GetAll(int? s, int? l, string q);
        public Task<AlquilerResponse> GetById(int id);
        public Task<AlquilerResponse> Create(AlquilerRequest newAlquiler);
        public Task<AlquilerResponse> Update(AlquilerRequest updatedAlquiler);
        public Task<bool> Delete(int id);
    }
}
