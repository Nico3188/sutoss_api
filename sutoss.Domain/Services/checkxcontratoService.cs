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
    public class checkxcontratosService : BaseService, IcheckxcontratosService
    {
        private readonly IcheckxcontratoRepository _checkxcontratoRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public checkxcontratosService(
            IcheckxcontratoRepository checkxcontratoRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _checkxcontratoRepository = checkxcontratoRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<checkxcontratoResponse> Create(checkxcontratoRequest newcheckxcontrato, string externalUserId)
        {
            var transaction = _checkxcontratoRepository.BeginTransaction();
            try
            {

                checkxcontrato entity= _mapper.Map<checkxcontrato>(newcheckxcontrato);
                var addedcheckxcontrato = await _checkxcontratoRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<checkxcontratoResponse>(addedcheckxcontrato);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id, string externalUserId)
        {
            var transaction = _checkxcontratoRepository.BeginTransaction();
            try
            {
                var result = (await _checkxcontratoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "checkxcontrato not found");
                }
                await _checkxcontratoRepository.Delete(result.checkxcontratoId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<checkxcontratoResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<checkxcontrato> items = await _checkxcontratoRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<checkxcontratoResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<checkxcontratoResponse> GetById(int id)
        {
            try
            {
                var result = (await _checkxcontratoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "checkxcontrato not found");
                }
                return _mapper.Map<checkxcontratoResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<checkxcontratoResponse> Update(checkxcontratoRequest updatedcheckxcontrato, string externalUserId)
        {
            var transaction = _checkxcontratoRepository.BeginTransaction();
            try
            {

                var mappedcheckxcontrato = (await _checkxcontratoRepository.Get(updatedcheckxcontrato.checkxcontratoId)).FirstOrDefault();
		        var result = await _checkxcontratoRepository.Update(mappedcheckxcontrato);
                var mappedResponse = _mapper.Map<checkxcontratoResponse>(result);
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
