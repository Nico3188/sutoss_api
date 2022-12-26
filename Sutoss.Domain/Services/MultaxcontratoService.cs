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
    public class MultaxcontratosService : BaseService, IMultaxcontratosService
    {
        private readonly IMultaxcontratoRepository _MultaxcontratoRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public MultaxcontratosService(
            IMultaxcontratoRepository MultaxcontratoRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _MultaxcontratoRepository = MultaxcontratoRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<MultaxcontratoResponse> Create(MultaxcontratoRequest newMultaxcontrato )
        {
            var transaction = _MultaxcontratoRepository.BeginTransaction();
            try
            {

                Multaxcontrato entity= _mapper.Map<Multaxcontrato>(newMultaxcontrato);
                var addedMultaxcontrato = await _MultaxcontratoRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<MultaxcontratoResponse>(addedMultaxcontrato);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {
            var transaction = _MultaxcontratoRepository.BeginTransaction();
            try
            {
                var result = (await _MultaxcontratoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Multaxcontrato not found");
                }
                await _MultaxcontratoRepository.Delete(result.IdMultaxContrato);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<MultaxcontratoResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<Multaxcontrato> items = await _MultaxcontratoRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<MultaxcontratoResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<MultaxcontratoResponse> GetById(int id)
        {
            try
            {
                var result = (await _MultaxcontratoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Multaxcontrato not found");
                }
                return _mapper.Map<MultaxcontratoResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<MultaxcontratoResponse> Update(MultaxcontratoRequest updatedMultaxcontrato )
        {
            var transaction = _MultaxcontratoRepository.BeginTransaction();
            try
            {

                var mappedMultaxcontrato = (await _MultaxcontratoRepository.Get(updatedMultaxcontrato.IdMultaxContrato)).FirstOrDefault();
		        var result = await _MultaxcontratoRepository.Update(mappedMultaxcontrato);
                var mappedResponse = _mapper.Map<MultaxcontratoResponse>(result);
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
