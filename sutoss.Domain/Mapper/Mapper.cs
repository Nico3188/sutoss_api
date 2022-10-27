using AutoMapper;
using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;

namespace sutoss.Domain.Services.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            ///// Request
            CreateMap<BundleRequest, Bundle>();
            CreateMap<HealtcareVisitDocumentRequest, HealtcareVisitDocument>();
            CreateMap<HealtcareVisitDocumentTypeRequest, HealtcareVisitDocumentType>();
            CreateMap<HealtcareVisitProgressRequest, HealtcareVisitProgress>();
            CreateMap<HealtcareVisitRequest, HealtcareVisit>();
            CreateMap<HealtcareVisitTypeRequest, HealtcareVisitType>();
            CreateMap<OwnerRequest, Owner>();
            CreateMap<PaymentRequest, Payment>();
            CreateMap<PetRequest, Pet>();
            CreateMap<PetServiceRequest, PetService>();
            CreateMap<PetTypeRequest, PetType>();
            CreateMap<RefundRequest, Refund>();
            CreateMap<RoleRequest, Role>();
            CreateMap<ServiceItemRequest, ServiceItem>();
            CreateMap<ServiceRequest, Service>();
            CreateMap<UserRequest, User>();
            CreateMap<UserRoleRequest, UserRole>();

            ///// Responses
            CreateMap<Bundle, BundleResponse>();
            CreateMap<HealtcareVisitDocument, HealtcareVisitDocumentResponse>();
            CreateMap<HealtcareVisitDocumentType, HealtcareVisitDocumentTypeResponse>();
            CreateMap<HealtcareVisitProgress, HealtcareVisitProgressResponse>();
            CreateMap<HealtcareVisit, HealtcareVisitResponse>();
            CreateMap<HealtcareVisitType, HealtcareVisitTypeResponse>();
            CreateMap<Owner, OwnerResponse>();
            CreateMap<Payment, PaymentResponse>();
            CreateMap<Pet, PetResponse>();
            CreateMap<PetService, PetServiceResponse>();
            CreateMap<PetType, PetTypeResponse>();
            CreateMap<Refund, RefundResponse>();
            CreateMap<Role, RoleResponse>();
            CreateMap<ServiceItem, ServiceItemResponse>();
            CreateMap<Service, ServiceResponse>();
            CreateMap<User, UserResponse>();
            CreateMap<UserRole, UserRoleResponse>();
        }
    }
}
