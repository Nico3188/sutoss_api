using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IHealtcareVisitsService
    {
        public Task<List<HealtcareVisitResponse>> GetAll(int? s, int? l, string q);
        public Task<HealtcareVisitResponse> GetById(int id);
        public Task<HealtcareVisitResponse> Create(HealtcareVisitRequest newHealtcareVisit);
        public Task<HealtcareVisitResponse> Update(HealtcareVisitRequest updatedHealtcareVisit);
        public Task<bool> Delete(int id);
    }
}
