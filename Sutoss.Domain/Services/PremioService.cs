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
    public class PremiosService : BaseService, IPremiosService
    {
        private readonly IPremioRepository _PremioRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public PremiosService(
            IPremioRepository PremioRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _PremioRepository = PremioRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<PremioResponse> Create(PremioRequest newPremio )
        {
            var transaction = _PremioRepository.BeginTransaction();
            try
            {

                Premio entity= _mapper.Map<Premio>(newPremio);
                var addedPremio = await _PremioRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<PremioResponse>(addedPremio);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {
            var transaction = _PremioRepository.BeginTransaction();
            try
            {
                var result = (await _PremioRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Premio not found");
                }
                await _PremioRepository.Delete(result.IdPremios);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<PremioResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<Premio> items = await _PremioRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<PremioResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PremioResponse> GetById(int id)
        {
            try
            {
                var result = (await _PremioRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Premio not found");
                }
                return _mapper.Map<PremioResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PremioResponse> Update(PremioRequest updatedPremio )
        {
            var transaction = _PremioRepository.BeginTransaction();
            try
            {

                var mappedPremio = (await _PremioRepository.Get(updatedPremio.IdPremios)).FirstOrDefault();
		        var result = await _PremioRepository.Update(mappedPremio);
                var mappedResponse = _mapper.Map<PremioResponse>(result);
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
