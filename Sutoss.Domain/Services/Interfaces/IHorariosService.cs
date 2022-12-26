using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IHorariosService
    {
        public Task<List<HorarioResponse>> GetAll(int? s, int? l, string q);
        public Task<HorarioResponse> GetById(int id);
        public Task<HorarioResponse> Create(HorarioRequest newHorario);
        public Task<HorarioResponse> Update(HorarioRequest updatedHorario);
        public Task<bool> Delete(int id);
    }
}
