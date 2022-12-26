using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IDesignacionsService
    {
        public Task<List<DesignacionResponse>> GetAll(int? s, int? l, string q);
        public Task<DesignacionResponse> GetById(int id);
        public Task<DesignacionResponse> Create(DesignacionRequest newDesignacion);
        public Task<DesignacionResponse> Update(DesignacionRequest updatedDesignacion);
        public Task<bool> Delete(int id);
    }
}
