using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface Idetalle_comprasService
    {
        public Task<List<detalle_compraResponse>> GetAll(int? s, int? l, string q);
        public Task<detalle_compraResponse> GetById(int id);
        public Task<detalle_compraResponse> Create(detalle_compraRequest newdetalle_compra, string userId);
        public Task<detalle_compraResponse> Update(detalle_compraRequest updateddetalle_compra, string userId);
        public Task<bool> Delete(int id, string userId);
    }
}
