using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IMultaxcontratosService
    {
        public Task<List<MultaxcontratoResponse>> GetAll(int? s, int? l, string q);
        public Task<MultaxcontratoResponse> GetById(int id);
        public Task<MultaxcontratoResponse> Create(MultaxcontratoRequest newMultaxcontrato);
        public Task<MultaxcontratoResponse> Update(MultaxcontratoRequest updatedMultaxcontrato);
        public Task<bool> Delete(int id);
    }
}
