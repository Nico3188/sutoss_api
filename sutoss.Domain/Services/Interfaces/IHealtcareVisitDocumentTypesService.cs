using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IHealtcareVisitDocumentTypesService
    {
        public Task<List<HealtcareVisitDocumentTypeResponse>> GetAll(int? s, int? l, string q);
        public Task<HealtcareVisitDocumentTypeResponse> GetById(int id);
        public Task<HealtcareVisitDocumentTypeResponse> Create(HealtcareVisitDocumentTypeRequest newHealtcareVisitDocumentType);
        public Task<HealtcareVisitDocumentTypeResponse> Update(HealtcareVisitDocumentTypeRequest updatedHealtcareVisitDocumentType);
        public Task<bool> Delete(int id);
    }
}
