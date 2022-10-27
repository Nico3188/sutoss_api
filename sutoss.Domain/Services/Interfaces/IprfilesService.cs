using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IprfilesService
    {
        public Task<List<perfilResponse>> GetAll(int? s, int? l, string q);
        public Task<perfilResponse> GetById(int id);
        public Task<perfilResponse> Create(perfilRequest newperfil, string userId);
        public Task<perfilResponse> Update(perfilRequest updatedperfil, string userId);
        public Task<bool> Delete(int id, string userId);
    }
}
