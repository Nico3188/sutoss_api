using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface ILogOperacionesService
    {
        public Task<List<LogOperacioneResponse>> GetAll(int? s, int? l, string q);
        public Task<LogOperacioneResponse> GetById(int id);
        public Task<LogOperacioneResponse> Create(LogOperacioneRequest newLogOperacione);
        public Task<LogOperacioneResponse> Update(LogOperacioneRequest updatedLogOperacione);
        public Task<bool> Delete(int id);
    }
}
