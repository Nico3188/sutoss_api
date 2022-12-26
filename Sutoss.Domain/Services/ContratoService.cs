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
    public class ContratosService : BaseService, IContratosService
    {
        private readonly IContratoRepository _ContratoRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public ContratosService(
            IContratoRepository ContratoRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _ContratoRepository = ContratoRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<ContratoResponse> Create(ContratoRequest newContrato )
        {
            var transaction = _ContratoRepository.BeginTransaction();
            try
            {

                Contrato entity= _mapper.Map<Contrato>(newContrato);
                var addedContrato = await _ContratoRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<ContratoResponse>(addedContrato);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {
            var transaction = _ContratoRepository.BeginTransaction();
            try
            {
                var result = (await _ContratoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Contrato not found");
                }
                await _ContratoRepository.Delete(result.IdContrato);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<ContratoResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<Contrato> items = await _ContratoRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<ContratoResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ContratoResponse> GetById(int id)
        {
            try
            {
                var result = (await _ContratoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Contrato not found");
                }
                return _mapper.Map<ContratoResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ContratoResponse> Update(ContratoRequest updatedContrato )
        {
            var transaction = _ContratoRepository.BeginTransaction();
            try
            {

                var mappedContrato = (await _ContratoRepository.Get(updatedContrato.IdContrato)).FirstOrDefault();
		        var result = await _ContratoRepository.Update(mappedContrato);
                var mappedResponse = _mapper.Map<ContratoResponse>(result);
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
