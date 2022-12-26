using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface ICuotaAnticiposService
    {
        public Task<List<CuotaAnticipoResponse>> GetAll(int? s, int? l, string q);
        public Task<CuotaAnticipoResponse> GetById(int id);
        public Task<CuotaAnticipoResponse> Create(CuotaAnticipoRequest newCuotaAnticipo);
        public Task<CuotaAnticipoResponse> Update(CuotaAnticipoRequest updatedCuotaAnticipo);
        public Task<bool> Delete(int id);
    }
}
