using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IPetServicesService
    {
        public Task<List<PetServiceResponse>> GetAll(int? s, int? l, string q);
        public Task<PetServiceResponse> GetById(int id);
        public Task<PetServiceResponse> Create(PetServiceRequest newPetService);
        public Task<PetServiceResponse> Update(PetServiceRequest updatedPetService);
        public Task<bool> Delete(int id);
    }
}
