using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface ImultasxcontradoService
    {
        public Task<List<multaxcontratoResponse>> GetAll(int? s, int? l, string q);
        public Task<multaxcontratoResponse> GetById(int id);
        public Task<multaxcontratoResponse> Create(multaxcontratoRequest newmultaxcontrato, string userId);
        public Task<multaxcontratoResponse> Update(multaxcontratoRequest updatedmultaxcontrato, string userId);
        public Task<bool> Delete(int id, string userId);
    }
}
