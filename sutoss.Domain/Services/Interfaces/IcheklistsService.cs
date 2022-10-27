using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IcheklistsService
    {
        public Task<List<cheklistResponse>> GetAll(int? s, int? l, string q);
        public Task<cheklistResponse> GetById(int id);
        public Task<cheklistResponse> Create(cheklistRequest newcheklist, string userId);
        public Task<cheklistResponse> Update(cheklistRequest updatedcheklist, string userId);
        public Task<bool> Delete(int id, string userId);
    }
}
