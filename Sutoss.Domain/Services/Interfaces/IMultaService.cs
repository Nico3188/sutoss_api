using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IMultaService
    {
        public Task<List<MultumResponse>> GetAll(int? s, int? l, string q);
        public Task<MultumResponse> GetById(int id);
        public Task<MultumResponse> Create(MultumRequest newMultum);
        public Task<MultumResponse> Update(MultumRequest updatedMultum);
        public Task<bool> Delete(int id);
    }
}
