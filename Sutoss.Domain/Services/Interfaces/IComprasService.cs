using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IComprasService
    {
        public Task<List<CompraResponse>> GetAll(int? s, int? l, string q);
        public Task<CompraResponse> GetById(int id);
        public Task<CompraResponse> Create(CompraRequest newCompra);
        public Task<CompraResponse> Update(CompraRequest updatedCompra);
        public Task<bool> Delete(int id);
    }
}
