using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IImpxinstalacionsService
    {
        public Task<List<ImpxinstalacionResponse>> GetAll(int? s, int? l, string q);
        public Task<ImpxinstalacionResponse> GetById(int id);
        public Task<ImpxinstalacionResponse> Create(ImpxinstalacionRequest newImpxinstalacion);
        public Task<ImpxinstalacionResponse> Update(ImpxinstalacionRequest updatedImpxinstalacion);
        public Task<bool> Delete(int id);
    }
}
