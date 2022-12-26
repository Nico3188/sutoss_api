using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IEnferemedadsService
    {
        public Task<List<EnferemedadResponse>> GetAll(int? s, int? l, string q);
        public Task<EnferemedadResponse> GetById(int id);
        public Task<EnferemedadResponse> Create(EnferemedadRequest newEnferemedad);
        public Task<EnferemedadResponse> Update(EnferemedadRequest updatedEnferemedad);
        public Task<bool> Delete(int id);
    }
}
