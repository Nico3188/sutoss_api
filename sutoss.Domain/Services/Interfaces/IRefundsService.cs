using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IRefundsService
    {
        public Task<List<RefundResponse>> GetAll(int? s, int? l, string q);
        public Task<RefundResponse> GetById(int id);
        public Task<RefundResponse> Create(RefundRequest newRefund);
        public Task<RefundResponse> Update(RefundRequest updatedRefund);
        public Task<bool> Delete(int id);
    }
}
