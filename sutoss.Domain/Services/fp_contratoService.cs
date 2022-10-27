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
    public class fp_contratosService : BaseService, Ifp_contratosService
    {
        private readonly Ifp_contratoRepository _fp_contratoRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public fp_contratosService(
            Ifp_contratoRepository fp_contratoRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _fp_contratoRepository = fp_contratoRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<fp_contratoResponse> Create(fp_contratoRequest newfp_contrato, string externalUserId)
        {
            var transaction = _fp_contratoRepository.BeginTransaction();
            try
            {

                fp_contrato entity= _mapper.Map<fp_contrato>(newfp_contrato);
                var addedfp_contrato = await _fp_contratoRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<fp_contratoResponse>(addedfp_contrato);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id, string externalUserId)
        {
            var transaction = _fp_contratoRepository.BeginTransaction();
            try
            {
                var result = (await _fp_contratoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "fp_contrato not found");
                }
                await _fp_contratoRepository.Delete(result.fp_contratoId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<fp_contratoResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<fp_contrato> items = await _fp_contratoRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<fp_contratoResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<fp_contratoResponse> GetById(int id)
        {
            try
            {
                var result = (await _fp_contratoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "fp_contrato not found");
                }
                return _mapper.Map<fp_contratoResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<fp_contratoResponse> Update(fp_contratoRequest updatedfp_contrato, string externalUserId)
        {
            var transaction = _fp_contratoRepository.BeginTransaction();
            try
            {

                var mappedfp_contrato = (await _fp_contratoRepository.Get(updatedfp_contrato.fp_contratoId)).FirstOrDefault();
		        var result = await _fp_contratoRepository.Update(mappedfp_contrato);
                var mappedResponse = _mapper.Map<fp_contratoResponse>(result);
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
