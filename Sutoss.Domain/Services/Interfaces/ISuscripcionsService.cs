using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface ISuscripcionsService
    {
        public Task<List<SuscripcionResponse>> GetAll(int? s, int? l, string q);
        public Task<SuscripcionResponse> GetById(int id);
        public Task<SuscripcionResponse> Create(SuscripcionRequest newSuscripcion);
        public Task<SuscripcionResponse> Update(SuscripcionRequest updatedSuscripcion);
        public Task<bool> Delete(int id);
    }
}
