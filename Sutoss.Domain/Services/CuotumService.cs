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
    public class CuotaService : BaseService, ICuotaService
    {
        private readonly ICuotumRepository _CuotumRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public CuotaService(
            ICuotumRepository CuotumRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _CuotumRepository = CuotumRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<CuotumResponse> Create(CuotumRequest newCuotum )
        {
            var transaction = _CuotumRepository.BeginTransaction();
            try
            {

                Cuotum entity= _mapper.Map<Cuotum>(newCuotum);
                var addedCuotum = await _CuotumRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<CuotumResponse>(addedCuotum);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {
            var transaction = _CuotumRepository.BeginTransaction();
            try
            {
                var result = (await _CuotumRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Cuotum not found");
                }
                await _CuotumRepository.Delete(result.IdCouta);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<CuotumResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<Cuotum> items = await _CuotumRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<CuotumResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CuotumResponse> GetById(int id)
        {
            try
            {
                var result = (await _CuotumRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Cuotum not found");
                }
                return _mapper.Map<CuotumResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CuotumResponse> Update(CuotumRequest updatedCuotum )
        {
            var transaction = _CuotumRepository.BeginTransaction();
            try
            {

                var mappedCuotum = (await _CuotumRepository.Get(updatedCuotum.IdCouta)).FirstOrDefault();
		        var result = await _CuotumRepository.Update(mappedCuotum);
                var mappedResponse = _mapper.Map<CuotumResponse>(result);
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
