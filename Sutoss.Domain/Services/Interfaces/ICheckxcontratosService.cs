using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface ICheckxcontratosService
    {
        public Task<List<CheckxcontratoResponse>> GetAll(int? s, int? l, string q);
        public Task<CheckxcontratoResponse> GetById(int id);
        public Task<CheckxcontratoResponse> Create(CheckxcontratoRequest newCheckxcontrato);
        public Task<CheckxcontratoResponse> Update(CheckxcontratoRequest updatedCheckxcontrato);
        public Task<bool> Delete(int id);
    }
}
