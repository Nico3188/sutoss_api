using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface ICuotaService
    {
        public Task<List<CuotumResponse>> GetAll(int? s, int? l, string q);
        public Task<CuotumResponse> GetById(int id);
        public Task<CuotumResponse> Create(CuotumRequest newCuotum);
        public Task<CuotumResponse> Update(CuotumRequest updatedCuotum);
        public Task<bool> Delete(int id);
    }
}
