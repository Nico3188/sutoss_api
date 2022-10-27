using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IganadoresService
    {
        public Task<List<ganadorResponse>> GetAll(int? s, int? l, string q);
        public Task<ganadorResponse> GetById(int id);
        public Task<ganadorResponse> Create(ganadorRequest newganador, string userId);
        public Task<ganadorResponse> Update(ganadorRequest updatedganador, string userId);
        public Task<bool> Delete(int id, string userId);
    }
}
