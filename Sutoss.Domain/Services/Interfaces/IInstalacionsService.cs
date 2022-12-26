using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IInstalacionsService
    {
        public Task<List<InstalacionResponse>> GetAll(int? s, int? l, string q);
        public Task<InstalacionResponse> GetById(int id);
        public Task<InstalacionResponse> Create(InstalacionRequest newInstalacion);
        public Task<InstalacionResponse> Update(InstalacionRequest updatedInstalacion);
        public Task<bool> Delete(int id);
    }
}
