using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IimpxinstalacionesService
    {
        public Task<List<impxinstalacionResponse>> GetAll(int? s, int? l, string q);
        public Task<impxinstalacionResponse> GetById(int id);
        public Task<impxinstalacionResponse> Create(impxinstalacionRequest newimpxinstalacion, string userId);
        public Task<impxinstalacionResponse> Update(impxinstalacionRequest updatedimpxinstalacion, string userId);
        public Task<bool> Delete(int id, string userId);
    }
}
