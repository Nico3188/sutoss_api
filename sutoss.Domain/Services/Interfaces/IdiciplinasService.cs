using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IdiciplinasService
    {
        public Task<List<diciplinaResponse>> GetAll(int? s, int? l, string q);
        public Task<diciplinaResponse> GetById(int id);
        public Task<diciplinaResponse> Create(diciplinaRequest newdiciplina, string userId);
        public Task<diciplinaResponse> Update(diciplinaRequest updateddiciplina, string userId);
        public Task<bool> Delete(int id, string userId);
    }
}
