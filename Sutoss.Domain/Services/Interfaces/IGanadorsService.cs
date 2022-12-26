using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IGanadorsService
    {
        public Task<List<GanadorResponse>> GetAll(int? s, int? l, string q);
        public Task<GanadorResponse> GetById(int id);
        public Task<GanadorResponse> Create(GanadorRequest newGanador);
        public Task<GanadorResponse> Update(GanadorRequest updatedGanador);
        public Task<bool> Delete(int id);
    }
}
