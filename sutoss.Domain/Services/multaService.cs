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
    public class multasService : BaseService, ImultasService
    {
        private readonly ImultaRepository _multaRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public multasService(
            ImultaRepository multaRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _multaRepository = multaRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<multaResponse> Create(multaRequest newmulta, string externalUserId)
        {
            var transaction = _multaRepository.BeginTransaction();
            try
            {

                multa entity= _mapper.Map<multa>(newmulta);
                var addedmulta = await _multaRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<multaResponse>(addedmulta);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id, string externalUserId)
        {
            var transaction = _multaRepository.BeginTransaction();
            try
            {
                var result = (await _multaRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "multa not found");
                }
                await _multaRepository.Delete(result.multaId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<multaResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<multa> items = await _multaRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<multaResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<multaResponse> GetById(int id)
        {
            try
            {
                var result = (await _multaRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "multa not found");
                }
                return _mapper.Map<multaResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<multaResponse> Update(multaRequest updatedmulta, string externalUserId)
        {
            var transaction = _multaRepository.BeginTransaction();
            try
            {

                var mappedmulta = (await _multaRepository.Get(updatedmulta.multaId)).FirstOrDefault();
		        var result = await _multaRepository.Update(mappedmulta);
                var mappedResponse = _mapper.Map<multaResponse>(result);
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
