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
    public class FamiliaService : BaseService, IFamiliaService
    {
        private readonly IFamiliumRepository _FamiliumRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public FamiliaService(
            IFamiliumRepository FamiliumRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _FamiliumRepository = FamiliumRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<FamiliumResponse> Create(FamiliumRequest newFamilium )
        {
            var transaction = _FamiliumRepository.BeginTransaction();
            try
            {

                Familium entity= _mapper.Map<Familium>(newFamilium);
                var addedFamilium = await _FamiliumRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<FamiliumResponse>(addedFamilium);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {
            var transaction = _FamiliumRepository.BeginTransaction();
            try
            {
                var result = (await _FamiliumRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Familium not found");
                }
                await _FamiliumRepository.Delete(result.IdFamilia);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<FamiliumResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<Familium> items = await _FamiliumRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<FamiliumResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<FamiliumResponse> GetById(int id)
        {
            try
            {
                var result = (await _FamiliumRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Familium not found");
                }
                return _mapper.Map<FamiliumResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<FamiliumResponse> Update(FamiliumRequest updatedFamilium )
        {
            var transaction = _FamiliumRepository.BeginTransaction();
            try
            {

                var mappedFamilium = (await _FamiliumRepository.Get(updatedFamilium.IdFamilia)).FirstOrDefault();
		        var result = await _FamiliumRepository.Update(mappedFamilium);
                var mappedResponse = _mapper.Map<FamiliumResponse>(result);
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
