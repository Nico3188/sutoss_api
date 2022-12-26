using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IBeneficiosService
    {
        public Task<List<BeneficioResponse>> GetAll(int? s, int? l, string q);
        public Task<BeneficioResponse> GetById(int id);
        public Task<BeneficioResponse> Create(BeneficioRequest newBeneficio);
        public Task<BeneficioResponse> Update(BeneficioRequest updatedBeneficio);
        public Task<bool> Delete(int id);
    }
}
