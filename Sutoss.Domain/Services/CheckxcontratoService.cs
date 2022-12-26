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
    public class CheckxcontratosService : BaseService, ICheckxcontratosService
    {
        private readonly ICheckxcontratoRepository _CheckxcontratoRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public CheckxcontratosService(
            ICheckxcontratoRepository CheckxcontratoRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _CheckxcontratoRepository = CheckxcontratoRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<CheckxcontratoResponse> Create(CheckxcontratoRequest newCheckxcontrato )
        {
            var transaction = _CheckxcontratoRepository.BeginTransaction();
            try
            {

                Checkxcontrato entity= _mapper.Map<Checkxcontrato>(newCheckxcontrato);
                var addedCheckxcontrato = await _CheckxcontratoRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<CheckxcontratoResponse>(addedCheckxcontrato);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {
            var transaction = _CheckxcontratoRepository.BeginTransaction();
            try
            {
                var result = (await _CheckxcontratoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Checkxcontrato not found");
                }
                await _CheckxcontratoRepository.Delete(result.IdCheckxContrato);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<CheckxcontratoResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<Checkxcontrato> items = await _CheckxcontratoRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<CheckxcontratoResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CheckxcontratoResponse> GetById(int id)
        {
            try
            {
                var result = (await _CheckxcontratoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Checkxcontrato not found");
                }
                return _mapper.Map<CheckxcontratoResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CheckxcontratoResponse> Update(CheckxcontratoRequest updatedCheckxcontrato )
        {
            var transaction = _CheckxcontratoRepository.BeginTransaction();
            try
            {

                var mappedCheckxcontrato = (await _CheckxcontratoRepository.Get(updatedCheckxcontrato.IdCheckxContrato)).FirstOrDefault();
		        var result = await _CheckxcontratoRepository.Update(mappedCheckxcontrato);
                var mappedResponse = _mapper.Map<CheckxcontratoResponse>(result);
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
