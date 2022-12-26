using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IPersonasService
    {
        public Task<List<PersonaResponse>> GetAll(int? s, int? l, string q);
        public Task<PersonaResponse> GetById(int id);
        public Task<PersonaResponse> Create(PersonaRequest newPersona);
        public Task<PersonaResponse> Update(PersonaRequest updatedPersona);
        public Task<bool> Delete(int id);
    }
}
