using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface Ifromas_pagoService
    {
        public Task<List<forma_pagoResponse>> GetAll(int? s, int? l, string q);
        public Task<forma_pagoResponse> GetById(int id);
        public Task<forma_pagoResponse> Create(forma_pagoRequest newforma_pago, string userId);
        public Task<forma_pagoResponse> Update(forma_pagoRequest updatedforma_pago, string userId);
        public Task<bool> Delete(int id, string userId);
    }
}
