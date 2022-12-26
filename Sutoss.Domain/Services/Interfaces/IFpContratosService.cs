using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IFpContratosService
    {
        public Task<List<FpContratoResponse>> GetAll(int? s, int? l, string q);
        public Task<FpContratoResponse> GetById(int id);
        public Task<FpContratoResponse> Create(FpContratoRequest newFpContrato);
        public Task<FpContratoResponse> Update(FpContratoRequest updatedFpContrato);
        public Task<bool> Delete(int id);
    }
}
