using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IPetTypesService
    {
        public Task<List<PetTypeResponse>> GetAll(int? s, int? l, string q);
        public Task<PetTypeResponse> GetById(int id);
        public Task<PetTypeResponse> Create(PetTypeRequest newPetType);
        public Task<PetTypeResponse> Update(PetTypeRequest updatedPetType);
        public Task<bool> Delete(int id);
    }
}
