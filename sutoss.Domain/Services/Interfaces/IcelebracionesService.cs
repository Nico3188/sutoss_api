using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IcelebracionesService
    {
        public Task<List<celebracionResponse>> GetAll(int? s, int? l, string q);
        public Task<celebracionResponse> GetById(int id);
        public Task<celebracionResponse> Create(celebracionRequest newcelebracion, string userId);
        public Task<celebracionResponse> Update(celebracionRequest updatedcelebracion, string userId);
        public Task<bool> Delete(int id, string userId);
    }
}
