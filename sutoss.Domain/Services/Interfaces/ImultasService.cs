using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface ImultasService
    {
        public Task<List<multaResponse>> GetAll(int? s, int? l, string q);
        public Task<multaResponse> GetById(int id);
        public Task<multaResponse> Create(multaRequest newmulta, string userId);
        public Task<multaResponse> Update(multaRequest updatedmulta, string userId);
        public Task<bool> Delete(int id, string userId);
    }
}
