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
    public class DepartamentosService : BaseService, IDepartamentosService
    {
        private readonly IDepartamentoRepository _DepartamentoRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public DepartamentosService(
            IDepartamentoRepository DepartamentoRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _DepartamentoRepository = DepartamentoRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<DepartamentoResponse> Create(DepartamentoRequest newDepartamento )
        {
            var transaction = _DepartamentoRepository.BeginTransaction();
            try
            {

                Departamento entity= _mapper.Map<Departamento>(newDepartamento);
                var addedDepartamento = await _DepartamentoRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<DepartamentoResponse>(addedDepartamento);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {
            var transaction = _DepartamentoRepository.BeginTransaction();
            try
            {
                var result = (await _DepartamentoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Departamento not found");
                }
                await _DepartamentoRepository.Delete(result.IdDepartamento);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<DepartamentoResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<Departamento> items = await _DepartamentoRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<DepartamentoResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DepartamentoResponse> GetById(int id)
        {
            try
            {
                var result = (await _DepartamentoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Departamento not found");
                }
                return _mapper.Map<DepartamentoResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DepartamentoResponse> Update(DepartamentoRequest updatedDepartamento )
        {
            var transaction = _DepartamentoRepository.BeginTransaction();
            try
            {

                var mappedDepartamento = (await _DepartamentoRepository.Get(updatedDepartamento.IdDepartamento)).FirstOrDefault();
		        var result = await _DepartamentoRepository.Update(mappedDepartamento);
                var mappedResponse = _mapper.Map<DepartamentoResponse>(result);
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
