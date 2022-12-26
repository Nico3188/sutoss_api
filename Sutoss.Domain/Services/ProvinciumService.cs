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
    public class ProvinciaService : BaseService, IProvinciaService
    {
        private readonly IProvinciumRepository _ProvinciumRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public ProvinciaService(
            IProvinciumRepository ProvinciumRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _ProvinciumRepository = ProvinciumRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<ProvinciumResponse> Create(ProvinciumRequest newProvincium )
        {
            var transaction = _ProvinciumRepository.BeginTransaction();
            try
            {

                Provincium entity= _mapper.Map<Provincium>(newProvincium);
                var addedProvincium = await _ProvinciumRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<ProvinciumResponse>(addedProvincium);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {
            var transaction = _ProvinciumRepository.BeginTransaction();
            try
            {
                var result = (await _ProvinciumRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Provincium not found");
                }
                await _ProvinciumRepository.Delete(result.IdProvincia);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<ProvinciumResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<Provincium> items = await _ProvinciumRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<ProvinciumResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProvinciumResponse> GetById(int id)
        {
            try
            {
                var result = (await _ProvinciumRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Provincium not found");
                }
                return _mapper.Map<ProvinciumResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProvinciumResponse> Update(ProvinciumRequest updatedProvincium )
        {
            var transaction = _ProvinciumRepository.BeginTransaction();
            try
            {

                var mappedProvincium = (await _ProvinciumRepository.Get(updatedProvincium.IdProvincia)).FirstOrDefault();
		        var result = await _ProvinciumRepository.Update(mappedProvincium);
                var mappedResponse = _mapper.Map<ProvinciumResponse>(result);
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
