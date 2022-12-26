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
    public class GastoxinstsService : BaseService, IGastoxinstsService
    {
        private readonly IGastoxinstRepository _GastoxinstRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public GastoxinstsService(
            IGastoxinstRepository GastoxinstRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _GastoxinstRepository = GastoxinstRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<GastoxinstResponse> Create(GastoxinstRequest newGastoxinst )
        {
            var transaction = _GastoxinstRepository.BeginTransaction();
            try
            {

                Gastoxinst entity= _mapper.Map<Gastoxinst>(newGastoxinst);
                var addedGastoxinst = await _GastoxinstRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<GastoxinstResponse>(addedGastoxinst);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {
            var transaction = _GastoxinstRepository.BeginTransaction();
            try
            {
                var result = (await _GastoxinstRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Gastoxinst not found");
                }
                await _GastoxinstRepository.Delete(result.IdGastoxInst);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<GastoxinstResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<Gastoxinst> items = await _GastoxinstRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<GastoxinstResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GastoxinstResponse> GetById(int id)
        {
            try
            {
                var result = (await _GastoxinstRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Gastoxinst not found");
                }
                return _mapper.Map<GastoxinstResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GastoxinstResponse> Update(GastoxinstRequest updatedGastoxinst )
        {
            var transaction = _GastoxinstRepository.BeginTransaction();
            try
            {

                var mappedGastoxinst = (await _GastoxinstRepository.Get(updatedGastoxinst.IdGastoxInst)).FirstOrDefault();
		        var result = await _GastoxinstRepository.Update(mappedGastoxinst);
                var mappedResponse = _mapper.Map<GastoxinstResponse>(result);
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
