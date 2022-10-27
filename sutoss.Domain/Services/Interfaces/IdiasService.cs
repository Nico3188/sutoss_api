using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IdiasService
    {
        public Task<List<diaResponse>> GetAll(int? s, int? l, string q);
        public Task<diaResponse> GetById(int id);
        public Task<diaResponse> Create(diaRequest newdia, string userId);
        public Task<diaResponse> Update(diaRequest updateddia, string userId);
        public Task<bool> Delete(int id, string userId);
    }
}
