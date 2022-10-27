using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IfamiliasService
    {
        public Task<List<familiaResponse>> GetAll(int? s, int? l, string q);
        public Task<familiaResponse> GetById(int id);
        public Task<familiaResponse> Create(familiaRequest newfamilia, string userId);
        public Task<familiaResponse> Update(familiaRequest updatedfamilia, string userId);
        public Task<bool> Delete(int id, string userId);
    }
}
