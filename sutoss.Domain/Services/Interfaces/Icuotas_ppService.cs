using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface Icuotas_ppService
    {
        public Task<List<cuota_ppResponse>> GetAll(int? s, int? l, string q);
        public Task<cuota_ppResponse> GetById(int id);
        public Task<cuota_ppResponse> Create(cuota_ppRequest newcuota_pp, string userId);
        public Task<cuota_ppResponse> Update(cuota_ppRequest updatedcuota_pp, string userId);
        public Task<bool> Delete(int id, string userId);
    }
}
