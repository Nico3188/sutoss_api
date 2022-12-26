using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface ICuotaPpsService
    {
        public Task<List<CuotaPpResponse>> GetAll(int? s, int? l, string q);
        public Task<CuotaPpResponse> GetById(int id);
        public Task<CuotaPpResponse> Create(CuotaPpRequest newCuotaPp);
        public Task<CuotaPpResponse> Update(CuotaPpRequest updatedCuotaPp);
        public Task<bool> Delete(int id);
    }
}
