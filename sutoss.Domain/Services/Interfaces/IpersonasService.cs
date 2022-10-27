using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IpersonasService
    {
        public Task<List<personaResponse>> GetAll(int? s, int? l, string q);
        public Task<personaResponse> GetById(int id);
        public Task<personaResponse> Create(personaRequest newpersona, string userId);
        public Task<personaResponse> Update(personaRequest updatedpersona, string userId);
        public Task<bool> Delete(int id, string userId);
    }
}
