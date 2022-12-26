using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IVicnulosService
    {
        public Task<List<VicnuloResponse>> GetAll(int? s, int? l, string q);
        public Task<VicnuloResponse> GetById(int id);
        public Task<VicnuloResponse> Create(VicnuloRequest newVicnulo);
        public Task<VicnuloResponse> Update(VicnuloRequest updatedVicnulo);
        public Task<bool> Delete(int id);
    }
}
