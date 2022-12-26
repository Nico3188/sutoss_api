using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IPremiosService
    {
        public Task<List<PremioResponse>> GetAll(int? s, int? l, string q);
        public Task<PremioResponse> GetById(int id);
        public Task<PremioResponse> Create(PremioRequest newPremio);
        public Task<PremioResponse> Update(PremioRequest updatedPremio);
        public Task<bool> Delete(int id);
    }
}
