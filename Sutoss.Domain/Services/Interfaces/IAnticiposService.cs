using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IAnticiposService
    {
        public Task<List<AnticipoResponse>> GetAll(int? s, int? l, string q);
        public Task<AnticipoResponse> GetById(int id);
        public Task<AnticipoResponse> Create(AnticipoRequest newAnticipo);
        public Task<AnticipoResponse> Update(AnticipoRequest updatedAnticipo);
        public Task<bool> Delete(int id);
    }
}
