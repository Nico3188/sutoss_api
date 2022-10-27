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
    public class familiasService : BaseService, IfamiliasService
    {
        private readonly IfamiliaRepository _familiaRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public familiasService(
            IfamiliaRepository familiaRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _familiaRepository = familiaRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<familiaResponse> Create(familiaRequest newfamilia, string externalUserId)
        {
            var transaction = _familiaRepository.BeginTransaction();
            try
            {

                familia entity= _mapper.Map<familia>(newfamilia);
                var addedfamilia = await _familiaRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<familiaResponse>(addedfamilia);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id, string externalUserId)
        {
            var transaction = _familiaRepository.BeginTransaction();
            try
            {
                var result = (await _familiaRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "familia not found");
                }
                await _familiaRepository.Delete(result.familiaId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<familiaResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<familia> items = await _familiaRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<familiaResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<familiaResponse> GetById(int id)
        {
            try
            {
                var result = (await _familiaRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "familia not found");
                }
                return _mapper.Map<familiaResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<familiaResponse> Update(familiaRequest updatedfamilia, string externalUserId)
        {
            var transaction = _familiaRepository.BeginTransaction();
            try
            {

                var mappedfamilia = (await _familiaRepository.Get(updatedfamilia.familiaId)).FirstOrDefault();
		        var result = await _familiaRepository.Update(mappedfamilia);
                var mappedResponse = _mapper.Map<familiaResponse>(result);
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
