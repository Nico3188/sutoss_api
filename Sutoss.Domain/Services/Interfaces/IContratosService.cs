using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IContratosService
    {
        public Task<List<ContratoResponse>> GetAll(int? s, int? l, string q);
        public Task<ContratoResponse> GetById(int id);
        public Task<ContratoResponse> Create(ContratoRequest newContrato);
        public Task<ContratoResponse> Update(ContratoRequest updatedContrato);
        public Task<bool> Delete(int id);
    }
}
