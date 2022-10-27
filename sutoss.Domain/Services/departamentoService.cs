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
    public class departamentosService : BaseService, IdepartamentosService
    {
        private readonly IdepartamentoRepository _departamentoRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public departamentosService(
            IdepartamentoRepository departamentoRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _departamentoRepository = departamentoRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<departamentoResponse> Create(departamentoRequest newdepartamento, string externalUserId)
        {
            var transaction = _departamentoRepository.BeginTransaction();
            try
            {

                departamento entity= _mapper.Map<departamento>(newdepartamento);
                var addeddepartamento = await _departamentoRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<departamentoResponse>(addeddepartamento);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id, string externalUserId)
        {
            var transaction = _departamentoRepository.BeginTransaction();
            try
            {
                var result = (await _departamentoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "departamento not found");
                }
                await _departamentoRepository.Delete(result.departamentoId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<departamentoResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<departamento> items = await _departamentoRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<departamentoResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<departamentoResponse> GetById(int id)
        {
            try
            {
                var result = (await _departamentoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "departamento not found");
                }
                return _mapper.Map<departamentoResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<departamentoResponse> Update(departamentoRequest updateddepartamento, string externalUserId)
        {
            var transaction = _departamentoRepository.BeginTransaction();
            try
            {

                var mappeddepartamento = (await _departamentoRepository.Get(updateddepartamento.departamentoId)).FirstOrDefault();
		        var result = await _departamentoRepository.Update(mappeddepartamento);
                var mappedResponse = _mapper.Map<departamentoResponse>(result);
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
