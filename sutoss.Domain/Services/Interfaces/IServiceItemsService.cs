using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IServiceItemsService
    {
        public Task<List<ServiceItemResponse>> GetAll(int? s, int? l, string q);
        public Task<ServiceItemResponse> GetById(int id);
        public Task<ServiceItemResponse> Create(ServiceItemRequest newServiceItem);
        public Task<ServiceItemResponse> Update(ServiceItemRequest updatedServiceItem);
        public Task<bool> Delete(int id);
    }
}
