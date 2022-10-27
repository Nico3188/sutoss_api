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
    public class multasxcontradoService : BaseService, ImultasxcontradoService
    {
        private readonly ImultaxcontratoRepository _multaxcontratoRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public multasxcontradoService(
            ImultaxcontratoRepository multaxcontratoRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _multaxcontratoRepository = multaxcontratoRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<multaxcontratoResponse> Create(multaxcontratoRequest newmultaxcontrato, string externalUserId)
        {
            var transaction = _multaxcontratoRepository.BeginTransaction();
            try
            {

                multaxcontrato entity= _mapper.Map<multaxcontrato>(newmultaxcontrato);
                var addedmultaxcontrato = await _multaxcontratoRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<multaxcontratoResponse>(addedmultaxcontrato);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id, string externalUserId)
        {
            var transaction = _multaxcontratoRepository.BeginTransaction();
            try
            {
                var result = (await _multaxcontratoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "multaxcontrato not found");
                }
                await _multaxcontratoRepository.Delete(result.multaxcontratoId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<multaxcontratoResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<multaxcontrato> items = await _multaxcontratoRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<multaxcontratoResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<multaxcontratoResponse> GetById(int id)
        {
            try
            {
                var result = (await _multaxcontratoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "multaxcontrato not found");
                }
                return _mapper.Map<multaxcontratoResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<multaxcontratoResponse> Update(multaxcontratoRequest updatedmultaxcontrato, string externalUserId)
        {
            var transaction = _multaxcontratoRepository.BeginTransaction();
            try
            {

                var mappedmultaxcontrato = (await _multaxcontratoRepository.Get(updatedmultaxcontrato.multaxcontratoId)).FirstOrDefault();
		        var result = await _multaxcontratoRepository.Update(mappedmultaxcontrato);
                var mappedResponse = _mapper.Map<multaxcontratoResponse>(result);
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
