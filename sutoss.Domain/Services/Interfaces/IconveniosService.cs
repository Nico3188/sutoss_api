using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IconveniosService
    {
        public Task<List<convenioResponse>> GetAll(int? s, int? l, string q);
        public Task<convenioResponse> GetById(int id);
        public Task<convenioResponse> Create(convenioRequest newconvenio, string userId);
        public Task<convenioResponse> Update(convenioRequest updatedconvenio, string userId);
        public Task<bool> Delete(int id, string userId);
    }
}
