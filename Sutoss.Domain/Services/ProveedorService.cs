using AutoMapper;
using Sutoss.Domain.Services.Domain.Filters;
using Sutoss.Domain.Services.Domain.Repositories.Interfaces;
using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;
using Sutoss.Domain.Services.Domain.Services.Base;
using Sutoss.Domain.Services.Domain.Services.Interfaces;
using Sutoss.Domain.Services.Exceptions;
using Sutoss.Domain.Services.Helpers;
using Sutoss.Domain.Services.Repositories;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace Sutoss.Domain.Services.Domain.Services
{
    public class ProveedorsService : BaseService, IProveedorsService
    {
        private readonly IProveedorRepository _ProveedorRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public ProveedorsService(
            IProveedorRepository ProveedorRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _ProveedorRepository = ProveedorRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<ProveedorResponse> Create(ProveedorRequest newProveedor )
        {
            var transaction = _ProveedorRepository.BeginTransaction();
            try
            {

                Proveedor entity= _mapper.Map<Proveedor>(newProveedor);
                var addedProveedor = await _ProveedorRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<ProveedorResponse>(addedProveedor);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {
            var transaction = _ProveedorRepository.BeginTransaction();
            try
            {
                var result = (await _ProveedorRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Proveedor not found");
                }
                await _ProveedorRepository.Delete(result.IdProveedor);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<ProveedorResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<Proveedor> items = await _ProveedorRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<ProveedorResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProveedorResponse> GetById(int id)
        {
            try
            {
                var result = (await _ProveedorRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Proveedor not found");
                }
                return _mapper.Map<ProveedorResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProveedorResponse> Update(ProveedorRequest updatedProveedor )
        {
            var transaction = _ProveedorRepository.BeginTransaction();
            try
            {

                var mappedProveedor = (await _ProveedorRepository.Get(updatedProveedor.IdProveedor)).FirstOrDefault();
		        var result = await _ProveedorRepository.Update(mappedProveedor);
                var mappedResponse = _mapper.Map<ProveedorResponse>(result);
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
