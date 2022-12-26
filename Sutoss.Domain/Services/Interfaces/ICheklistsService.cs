using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface ICheklistsService
    {
        public Task<List<CheklistResponse>> GetAll(int? s, int? l, string q);
        public Task<CheklistResponse> GetById(int id);
        public Task<CheklistResponse> Create(CheklistRequest newCheklist);
        public Task<CheklistResponse> Update(CheklistRequest updatedCheklist);
        public Task<bool> Delete(int id);
    }
}
