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
    public class ConveniosService : BaseService, IConveniosService
    {
        private readonly IConvenioRepository _ConvenioRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public ConveniosService(
            IConvenioRepository ConvenioRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _ConvenioRepository = ConvenioRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<ConvenioResponse> Create(ConvenioRequest newConvenio )
        {
            var transaction = _ConvenioRepository.BeginTransaction();
            try
            {

                Convenio entity= _mapper.Map<Convenio>(newConvenio);
                var addedConvenio = await _ConvenioRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<ConvenioResponse>(addedConvenio);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {
            var transaction = _ConvenioRepository.BeginTransaction();
            try
            {
                var result = (await _ConvenioRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Convenio not found");
                }
                await _ConvenioRepository.Delete(result.IdConvenio);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<ConvenioResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<Convenio> items = await _ConvenioRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<ConvenioResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ConvenioResponse> GetById(int id)
        {
            try
            {
                var result = (await _ConvenioRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Convenio not found");
                }
                return _mapper.Map<ConvenioResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ConvenioResponse> Update(ConvenioRequest updatedConvenio )
        {
            var transaction = _ConvenioRepository.BeginTransaction();
            try
            {

                var mappedConvenio = (await _ConvenioRepository.Get(updatedConvenio.IdConvenio)).FirstOrDefault();
		        var result = await _ConvenioRepository.Update(mappedConvenio);
                var mappedResponse = _mapper.Map<ConvenioResponse>(result);
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
