using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IserviciosService
    {
        public Task<List<servicioResponse>> GetAll(int? s, int? l, string q);
        public Task<servicioResponse> GetById(int id);
        public Task<servicioResponse> Create(servicioRequest newservicio, string userId);
        public Task<servicioResponse> Update(servicioRequest updatedservicio, string userId);
        public Task<bool> Delete(int id, string userId);
    }
}
