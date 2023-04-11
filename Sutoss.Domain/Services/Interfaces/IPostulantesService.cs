using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IPostulantesService
    {
        public Task<List<PostulanteResponse>> GetAll(int? s, int? l, string q);
        public Task<PostulanteResponse> GetById(int id);
        public Task<PostulanteResponse> Create(PostulanteRequest newPostulante);
        public Task<PostulanteResponse> Update(PostulanteRequest updatedPostulante);
        public Task<bool> Delete(int id);
    }
}
