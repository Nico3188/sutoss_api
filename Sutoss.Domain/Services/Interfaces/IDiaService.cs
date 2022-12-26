using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IDiaService
    {
        public Task<List<DiumResponse>> GetAll(int? s, int? l, string q);
        public Task<DiumResponse> GetById(int id);
        public Task<DiumResponse> Create(DiumRequest newDium);
        public Task<DiumResponse> Update(DiumRequest updatedDium);
        public Task<bool> Delete(int id);
    }
}
