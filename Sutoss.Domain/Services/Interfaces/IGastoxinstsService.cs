using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IGastoxinstsService
    {
        public Task<List<GastoxinstResponse>> GetAll(int? s, int? l, string q);
        public Task<GastoxinstResponse> GetById(int id);
        public Task<GastoxinstResponse> Create(GastoxinstRequest newGastoxinst);
        public Task<GastoxinstResponse> Update(GastoxinstRequest updatedGastoxinst);
        public Task<bool> Delete(int id);
    }
}
