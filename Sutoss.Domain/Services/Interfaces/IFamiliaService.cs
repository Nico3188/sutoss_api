using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IFamiliaService
    {
        public Task<List<FamiliumResponse>> GetAll(int? s, int? l, string q);
        public Task<FamiliumResponse> GetById(int id);
        public Task<FamiliumResponse> Create(FamiliumRequest newFamilium);
        public Task<FamiliumResponse> Update(FamiliumRequest updatedFamilium);
        public Task<bool> Delete(int id);
    }
}
