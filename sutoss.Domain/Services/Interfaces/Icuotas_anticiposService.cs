using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface Icuotas_anticiposService
    {
        public Task<List<cuota_anticipoResponse>> GetAll(int? s, int? l, string q);
        public Task<cuota_anticipoResponse> GetById(int id);
        public Task<cuota_anticipoResponse> Create(cuota_anticipoRequest newcuota_anticipo, string userId);
        public Task<cuota_anticipoResponse> Update(cuota_anticipoRequest updatedcuota_anticipo, string userId);
        public Task<bool> Delete(int id, string userId);
    }
}
