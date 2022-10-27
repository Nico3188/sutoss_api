using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IcheckxcontratosService
    {
        public Task<List<checkxcontratoResponse>> GetAll(int? s, int? l, string q);
        public Task<checkxcontratoResponse> GetById(int id);
        public Task<checkxcontratoResponse> Create(checkxcontratoRequest newcheckxcontrato, string userId);
        public Task<checkxcontratoResponse> Update(checkxcontratoRequest updatedcheckxcontrato, string userId);
        public Task<bool> Delete(int id, string userId);
    }
}
