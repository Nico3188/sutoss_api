using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IsuscripcionesService
    {
        public Task<List<suscripcionResponse>> GetAll(int? s, int? l, string q);
        public Task<suscripcionResponse> GetById(int id);
        public Task<suscripcionResponse> Create(suscripcionRequest newsuscripcion, string userId);
        public Task<suscripcionResponse> Update(suscripcionRequest updatedsuscripcion, string userId);
        public Task<bool> Delete(int id, string userId);
    }
}
