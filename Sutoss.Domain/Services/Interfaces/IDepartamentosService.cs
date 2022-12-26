using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IDepartamentosService
    {
        public Task<List<DepartamentoResponse>> GetAll(int? s, int? l, string q);
        public Task<DepartamentoResponse> GetById(int id);
        public Task<DepartamentoResponse> Create(DepartamentoRequest newDepartamento);
        public Task<DepartamentoResponse> Update(DepartamentoRequest updatedDepartamento);
        public Task<bool> Delete(int id);
    }
}
