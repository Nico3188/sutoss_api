using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IPetsService
    {
        public Task<List<PetResponse>> GetAll(int? s, int? l, string q);
        public Task<PetResponse> GetById(int id);
        public Task<PetResponse> Create(PetRequest newPet);
        public Task<PetResponse> Update(PetRequest updatedPet);
        public Task<bool> Delete(int id);
    }
}
