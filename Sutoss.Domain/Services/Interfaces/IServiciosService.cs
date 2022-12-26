using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IServiciosService
    {
        public Task<List<ServicioResponse>> GetAll(int? s, int? l, string q);
        public Task<ServicioResponse> GetById(int id);
        public Task<ServicioResponse> Create(ServicioRequest newServicio);
        public Task<ServicioResponse> Update(ServicioRequest updatedServicio);
        public Task<bool> Delete(int id);
    }
}
