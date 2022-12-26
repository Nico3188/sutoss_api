using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IDiciplinasService
    {
        public Task<List<DiciplinaResponse>> GetAll(int? s, int? l, string q);
        public Task<DiciplinaResponse> GetById(int id);
        public Task<DiciplinaResponse> Create(DiciplinaRequest newDiciplina);
        public Task<DiciplinaResponse> Update(DiciplinaRequest updatedDiciplina);
        public Task<bool> Delete(int id);
    }
}
