using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IIdiomasService
    {
        public Task<List<IdiomaResponse>> GetAll(int? s, int? l, string q);
        public Task<IdiomaResponse> GetById(int id);
        public Task<IdiomaResponse> Create(IdiomaRequest newIdioma);
        public Task<IdiomaResponse> Update(IdiomaRequest updatedIdioma);
        public Task<bool> Delete(int id);
    }
}
