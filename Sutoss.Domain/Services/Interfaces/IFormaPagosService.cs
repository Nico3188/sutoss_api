using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IFormaPagosService
    {
        public Task<List<FormaPagoResponse>> GetAll(int? s, int? l, string q);
        public Task<FormaPagoResponse> GetById(int id);
        public Task<FormaPagoResponse> Create(FormaPagoRequest newFormaPago);
        public Task<FormaPagoResponse> Update(FormaPagoRequest updatedFormaPago);
        public Task<bool> Delete(int id);
    }
}
