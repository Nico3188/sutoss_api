using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IPrestamosxpersonasService
    {
        public Task<List<PrestamosxpersonaResponse>> GetAll(int? s, int? l, string q);
        public Task<PrestamosxpersonaResponse> GetById(int id);
        public Task<PrestamosxpersonaResponse> Create(PrestamosxpersonaRequest newPrestamosxpersona);
        public Task<PrestamosxpersonaResponse> Update(PrestamosxpersonaRequest updatedPrestamosxpersona);
        public Task<bool> Delete(int id);
    }
}
