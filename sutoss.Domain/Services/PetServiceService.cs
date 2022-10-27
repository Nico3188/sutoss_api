using AutoMapper;
using sutoss.Domain.Services.Domain.Filters;
using sutoss.Domain.Services.Domain.Repositories.Interfaces;
using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using sutoss.Domain.Services.Domain.Services.Base;
using sutoss.Domain.Services.Domain.Services.Interfaces;
using sutoss.Domain.Services.Exceptions;
using sutoss.Domain.Services.Helpers;
using sutoss.Domain.Services.Repositories;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace sutoss.Domain.Services.Domain.Services
{
    public class PetServicesService : BaseService, IPetServicesService
    {
        private readonly IPetServiceRepository _PetServiceRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public PetServicesService(
            IPetServiceRepository PetServiceRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _PetServiceRepository = PetServiceRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<PetServiceResponse> Create(PetServiceRequest newPetService)
        {
            var transaction = _PetServiceRepository.BeginTransaction();
            try
            {

                PetService entity= _mapper.Map<PetService>(newPetService);
                var addedPetService = await _PetServiceRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<PetServiceResponse>(addedPetService);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var transaction = _PetServiceRepository.BeginTransaction();
            try
            {
                var result = (await _PetServiceRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "PetService not found");
                }
                await _PetServiceRepository.Delete(result.PetServiceId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<PetServiceResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<PetService> items = await _PetServiceRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<PetServiceResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PetServiceResponse> GetById(int id)
        {
            try
            {
                var result = (await _PetServiceRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "PetService not found");
                }
                return _mapper.Map<PetServiceResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PetServiceResponse> Update(PetServiceRequest updatedPetService)
        {
            var transaction = _PetServiceRepository.BeginTransaction();
            try
            {

                var mappedPetService = (await _PetServiceRepository.Get(updatedPetService.PetServiceId)).FirstOrDefault();
		        var result = await _PetServiceRepository.Update(mappedPetService);
                var mappedResponse = _mapper.Map<PetServiceResponse>(result);
                transaction.Commit();
                return mappedResponse;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

    }
}
