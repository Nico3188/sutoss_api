using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IBundlesService
    {
        public Task<List<BundleResponse>> GetAll(int? s, int? l, string q);
        public Task<BundleResponse> GetById(int id);
        public Task<BundleResponse> Create(BundleRequest newBundle);
        public Task<BundleResponse> Update(BundleRequest updatedBundle);
        public Task<bool> Delete(int id);
    }
}
