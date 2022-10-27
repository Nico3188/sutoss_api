using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IdepartamentosService
    {
        public Task<List<departamentoResponse>> GetAll(int? s, int? l, string q);
        public Task<departamentoResponse> GetById(int id);
        public Task<departamentoResponse> Create(departamentoRequest newdepartamento, string userId);
        public Task<departamentoResponse> Update(departamentoRequest updateddepartamento, string userId);
        public Task<bool> Delete(int id, string userId);
    }
}
