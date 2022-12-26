using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface ICelebracionsService
    {
        public Task<List<CelebracionResponse>> GetAll(int? s, int? l, string q);
        public Task<CelebracionResponse> GetById(int id);
        public Task<CelebracionResponse> Create(CelebracionRequest newCelebracion);
        public Task<CelebracionResponse> Update(CelebracionRequest updatedCelebracion);
        public Task<bool> Delete(int id);
    }
}
