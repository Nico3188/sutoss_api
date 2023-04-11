using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IExpereiciaLaboralsService
    {
        public Task<List<ExpereiciaLaboralResponse>> GetAll(int? s, int? l, string q);
        public Task<ExpereiciaLaboralResponse> GetById(int id);
        public Task<ExpereiciaLaboralResponse> Create(ExpereiciaLaboralRequest newExpereiciaLaboral);
        public Task<ExpereiciaLaboralResponse> Update(ExpereiciaLaboralRequest updatedExpereiciaLaboral);
        public Task<bool> Delete(int id);
    }
}
