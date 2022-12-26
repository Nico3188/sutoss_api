using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IImpuestosService
    {
        public Task<List<ImpuestoResponse>> GetAll(int? s, int? l, string q);
        public Task<ImpuestoResponse> GetById(int id);
        public Task<ImpuestoResponse> Create(ImpuestoRequest newImpuesto);
        public Task<ImpuestoResponse> Update(ImpuestoRequest updatedImpuesto);
        public Task<bool> Delete(int id);
    }
}
