using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IConveniosService
    {
        public Task<List<ConvenioResponse>> GetAll(int? s, int? l, string q);
        public Task<ConvenioResponse> GetById(int id);
        public Task<ConvenioResponse> Create(ConvenioRequest newConvenio);
        public Task<ConvenioResponse> Update(ConvenioRequest updatedConvenio);
        public Task<bool> Delete(int id);
    }
}
