using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IPerfilsService
    {
        public Task<List<PerfilResponse>> GetAll(int? s, int? l, string q);
        public Task<PerfilResponse> GetById(int id);
        public Task<PerfilResponse> Create(PerfilRequest newPerfil);
        public Task<PerfilResponse> Update(PerfilRequest updatedPerfil);
        public Task<bool> Delete(int id);
    }
}
