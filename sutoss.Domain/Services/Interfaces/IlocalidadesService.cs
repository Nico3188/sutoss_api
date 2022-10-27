using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IlocalidadesService
    {
        public Task<List<localidadResponse>> GetAll(int? s, int? l, string q);
        public Task<localidadResponse> GetById(int id);
        public Task<localidadResponse> Create(localidadRequest newlocalidad, string userId);
        public Task<localidadResponse> Update(localidadRequest updatedlocalidad, string userId);
        public Task<bool> Delete(int id, string userId);
    }
}
