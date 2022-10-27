using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IpretamosxpersonasService
    {
        public Task<List<prestamoxpersonaResponse>> GetAll(int? s, int? l, string q);
        public Task<prestamoxpersonaResponse> GetById(int id);
        public Task<prestamoxpersonaResponse> Create(prestamoxpersonaRequest newprestamoxpersona, string userId);
        public Task<prestamoxpersonaResponse> Update(prestamoxpersonaRequest updatedprestamoxpersona, string userId);
        public Task<bool> Delete(int id, string userId);
    }
}
