using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IinstalacionesService
    {
        public Task<List<instalacionResponse>> GetAll(int? s, int? l, string q);
        public Task<instalacionResponse> GetById(int id);
        public Task<instalacionResponse> Create(instalacionRequest newinstalacion, string userId);
        public Task<instalacionResponse> Update(instalacionRequest updatedinstalacion, string userId);
        public Task<bool> Delete(int id, string userId);
    }
}
