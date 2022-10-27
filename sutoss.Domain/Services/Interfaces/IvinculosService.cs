using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IvinculosService
    {
        public Task<List<vinculoResponse>> GetAll(int? s, int? l, string q);
        public Task<vinculoResponse> GetById(int id);
        public Task<vinculoResponse> Create(vinculoRequest newvinculo, string userId);
        public Task<vinculoResponse> Update(vinculoRequest updatedvinculo, string userId);
        public Task<bool> Delete(int id, string userId);
    }
}
