using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface Ifp_contratosService
    {
        public Task<List<fp_contratoResponse>> GetAll(int? s, int? l, string q);
        public Task<fp_contratoResponse> GetById(int id);
        public Task<fp_contratoResponse> Create(fp_contratoRequest newfp_contrato, string userId);
        public Task<fp_contratoResponse> Update(fp_contratoRequest updatedfp_contrato, string userId);
        public Task<bool> Delete(int id, string userId);
    }
}
