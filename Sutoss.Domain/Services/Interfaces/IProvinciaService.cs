using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IProvinciaService
    {
        public Task<List<ProvinciumResponse>> GetAll(int? s, int? l, string q);
        public Task<ProvinciumResponse> GetById(int id);
        public Task<ProvinciumResponse> Create(ProvinciumRequest newProvincium);
        public Task<ProvinciumResponse> Update(ProvinciumRequest updatedProvincium);
        public Task<bool> Delete(int id);
    }
}
