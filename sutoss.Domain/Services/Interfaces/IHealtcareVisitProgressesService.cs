using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IHealtcareVisitProgressesService
    {
        public Task<List<HealtcareVisitProgressResponse>> GetAll(int? s, int? l, string q);
        public Task<HealtcareVisitProgressResponse> GetById(int id);
        public Task<HealtcareVisitProgressResponse> Create(HealtcareVisitProgressRequest newHealtcareVisitProgress);
        public Task<HealtcareVisitProgressResponse> Update(HealtcareVisitProgressRequest updatedHealtcareVisitProgress);
        public Task<bool> Delete(int id);
    }
}
