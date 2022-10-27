using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IbeneficiosService
    {
        public Task<List<beneficioResponse>> GetAll(int? s, int? l, string q);
        public Task<beneficioResponse> GetById(int id);
        public Task<beneficioResponse> Create(beneficioRequest newbeneficio, string userId);
        public Task<beneficioResponse> Update(beneficioRequest updatedbeneficio, string userId);
        public Task<bool> Delete(int id, string userId);
    }
}
