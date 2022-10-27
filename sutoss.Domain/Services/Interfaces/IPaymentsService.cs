using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IPaymentsService
    {
        public Task<List<PaymentResponse>> GetAll(int? s, int? l, string q);
        public Task<PaymentResponse> GetById(int id);
        public Task<PaymentResponse> Create(PaymentRequest newPayment);
        public Task<PaymentResponse> Update(PaymentRequest updatedPayment);
        public Task<bool> Delete(int id);
    }
}
