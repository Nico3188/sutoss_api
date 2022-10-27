using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Services.Interfaces
{
    public interface IHealtcareVisitDocumentsService
    {
        public Task<List<HealtcareVisitDocumentResponse>> GetAll(int? s, int? l, string q);
        public Task<HealtcareVisitDocumentResponse> GetById(int id);
        public Task<HealtcareVisitDocumentResponse> Create(HealtcareVisitDocumentRequest newHealtcareVisitDocument);
        public Task<HealtcareVisitDocumentResponse> Update(HealtcareVisitDocumentRequest updatedHealtcareVisitDocument);
        public Task<bool> Delete(int id);
    }
}
