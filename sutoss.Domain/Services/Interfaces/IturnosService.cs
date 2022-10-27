using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IturnosService
    {
        public Task<List<turnoResponse>> GetAll(int? s, int? l, string q);
        public Task<turnoResponse> GetById(int id);
        public Task<turnoResponse> Create(turnoRequest newturno, string userId);
        public Task<turnoResponse> Update(turnoRequest updatedturno, string userId);
        public Task<bool> Delete(int id, string userId);
    }
}
