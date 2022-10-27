using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IServicesService
    {
        public Task<List<ServiceResponse>> GetAll(int? s, int? l, string q);
        public Task<ServiceResponse> GetById(int id);
        public Task<ServiceResponse> Create(ServiceRequest newService);
        public Task<ServiceResponse> Update(ServiceRequest updatedService);
        public Task<bool> Delete(int id);
    }
}
