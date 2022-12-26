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
    public class CuotaPpsService : BaseService, ICuotaPpsService
    {
        private readonly ICuotaPpRepository _CuotaPpRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public CuotaPpsService(
            ICuotaPpRepository CuotaPpRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _CuotaPpRepository = CuotaPpRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<CuotaPpResponse> Create(CuotaPpRequest newCuotaPp )
        {
            var transaction = _CuotaPpRepository.BeginTransaction();
            try
            {

                CuotaPp entity= _mapper.Map<CuotaPp>(newCuotaPp);
                var addedCuotaPp = await _CuotaPpRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<CuotaPpResponse>(addedCuotaPp);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {
            var transaction = _CuotaPpRepository.BeginTransaction();
            try
            {
                var result = (await _CuotaPpRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "CuotaPp not found");
                }
                await _CuotaPpRepository.Delete(result.IdCuotaPp);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<CuotaPpResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<CuotaPp> items = await _CuotaPpRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<CuotaPpResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CuotaPpResponse> GetById(int id)
        {
            try
            {
                var result = (await _CuotaPpRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "CuotaPp not found");
                }
                return _mapper.Map<CuotaPpResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CuotaPpResponse> Update(CuotaPpRequest updatedCuotaPp )
        {
            var transaction = _CuotaPpRepository.BeginTransaction();
            try
            {

                var mappedCuotaPp = (await _CuotaPpRepository.Get(updatedCuotaPp.IdCuotaPp)).FirstOrDefault();
		        var result = await _CuotaPpRepository.Update(mappedCuotaPp);
                var mappedResponse = _mapper.Map<CuotaPpResponse>(result);
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
