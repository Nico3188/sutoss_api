using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IHealtcareVisitTypesService
    {
        public Task<List<HealtcareVisitTypeResponse>> GetAll(int? s, int? l, string q);
        public Task<HealtcareVisitTypeResponse> GetById(int id);
        public Task<HealtcareVisitTypeResponse> Create(HealtcareVisitTypeRequest newHealtcareVisitType);
        public Task<HealtcareVisitTypeResponse> Update(HealtcareVisitTypeRequest updatedHealtcareVisitType);
        public Task<bool> Delete(int id);
    }
}
