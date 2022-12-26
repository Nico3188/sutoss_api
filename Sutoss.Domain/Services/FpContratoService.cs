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
    public class FpContratosService : BaseService, IFpContratosService
    {
        private readonly IFpContratoRepository _FpContratoRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public FpContratosService(
            IFpContratoRepository FpContratoRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _FpContratoRepository = FpContratoRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<FpContratoResponse> Create(FpContratoRequest newFpContrato )
        {
            var transaction = _FpContratoRepository.BeginTransaction();
            try
            {

                FpContrato entity= _mapper.Map<FpContrato>(newFpContrato);
                var addedFpContrato = await _FpContratoRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<FpContratoResponse>(addedFpContrato);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {
            var transaction = _FpContratoRepository.BeginTransaction();
            try
            {
                var result = (await _FpContratoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "FpContrato not found");
                }
                await _FpContratoRepository.Delete(result.IdFpContrato);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<FpContratoResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<FpContrato> items = await _FpContratoRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<FpContratoResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<FpContratoResponse> GetById(int id)
        {
            try
            {
                var result = (await _FpContratoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "FpContrato not found");
                }
                return _mapper.Map<FpContratoResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<FpContratoResponse> Update(FpContratoRequest updatedFpContrato )
        {
            var transaction = _FpContratoRepository.BeginTransaction();
            try
            {

                var mappedFpContrato = (await _FpContratoRepository.Get(updatedFpContrato.IdFpContrato)).FirstOrDefault();
		        var result = await _FpContratoRepository.Update(mappedFpContrato);
                var mappedResponse = _mapper.Map<FpContratoResponse>(result);
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
