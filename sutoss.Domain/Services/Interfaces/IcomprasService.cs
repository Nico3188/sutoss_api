using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IcomprasService
    {
        public Task<List<compraResponse>> GetAll(int? s, int? l, string q);
        public Task<compraResponse> GetById(int id);
        public Task<compraResponse> Create(compraRequest newcompra, string userId);
        public Task<compraResponse> Update(compraRequest updatedcompra, string userId);
        public Task<bool> Delete(int id, string userId);
    }
}
