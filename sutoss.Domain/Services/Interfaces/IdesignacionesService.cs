using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IdesignacionesService
    {
        public Task<List<designacionResponse>> GetAll(int? s, int? l, string q);
        public Task<designacionResponse> GetById(int id);
        public Task<designacionResponse> Create(designacionRequest newdesignacion, string userId);
        public Task<designacionResponse> Update(designacionRequest updateddesignacion, string userId);
        public Task<bool> Delete(int id, string userId);
    }
}
