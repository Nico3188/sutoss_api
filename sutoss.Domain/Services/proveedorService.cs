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
    public class proveedoresService : BaseService, IproveedoresService
    {
        private readonly IproveedorRepository _proveedorRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public proveedoresService(
            IproveedorRepository proveedorRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _proveedorRepository = proveedorRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<proveedorResponse> Create(proveedorRequest newproveedor, string externalUserId)
        {
            var transaction = _proveedorRepository.BeginTransaction();
            try
            {

                proveedor entity= _mapper.Map<proveedor>(newproveedor);
                var addedproveedor = await _proveedorRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<proveedorResponse>(addedproveedor);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id, string externalUserId)
        {
            var transaction = _proveedorRepository.BeginTransaction();
            try
            {
                var result = (await _proveedorRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "proveedor not found");
                }
                await _proveedorRepository.Delete(result.proveedorId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<proveedorResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<proveedor> items = await _proveedorRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<proveedorResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<proveedorResponse> GetById(int id)
        {
            try
            {
                var result = (await _proveedorRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "proveedor not found");
                }
                return _mapper.Map<proveedorResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<proveedorResponse> Update(proveedorRequest updatedproveedor, string externalUserId)
        {
            var transaction = _proveedorRepository.BeginTransaction();
            try
            {

                var mappedproveedor = (await _proveedorRepository.Get(updatedproveedor.proveedorId)).FirstOrDefault();
		        var result = await _proveedorRepository.Update(mappedproveedor);
                var mappedResponse = _mapper.Map<proveedorResponse>(result);
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
