using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface Iproductos_asignadosService
    {
        public Task<List<producto_asignadoResponse>> GetAll(int? s, int? l, string q);
        public Task<producto_asignadoResponse> GetById(int id);
        public Task<producto_asignadoResponse> Create(producto_asignadoRequest newproducto_asignado, string userId);
        public Task<producto_asignadoResponse> Update(producto_asignadoRequest updatedproducto_asignado, string userId);
        public Task<bool> Delete(int id, string userId);
    }
}
