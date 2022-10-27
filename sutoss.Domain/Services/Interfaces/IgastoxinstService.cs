using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IgastoxinstService
    {
        public Task<List<gastoxinstResponse>> GetAll(int? s, int? l, string q);
        public Task<gastoxinstResponse> GetById(int id);
        public Task<gastoxinstResponse> Create(gastoxinstRequest newgastoxinst, string userId);
        public Task<gastoxinstResponse> Update(gastoxinstRequest updatedgastoxinst, string userId);
        public Task<bool> Delete(int id, string userId);
    }
}
