using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IcuotasService
    {
        public Task<List<cuotaResponse>> GetAll(int? s, int? l, string q);
        public Task<cuotaResponse> GetById(int id);
        public Task<cuotaResponse> Create(cuotaRequest newcuota, string userId);
        public Task<cuotaResponse> Update(cuotaRequest updatedcuota, string userId);
        public Task<bool> Delete(int id, string userId);
    }
}
