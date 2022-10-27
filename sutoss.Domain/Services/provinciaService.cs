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
    public class provinciasService : BaseService, IprovinciasService
    {
        private readonly IprovinciaRepository _provinciaRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public provinciasService(
            IprovinciaRepository provinciaRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _provinciaRepository = provinciaRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<provinciaResponse> Create(provinciaRequest newprovincia, string externalUserId)
        {
            var transaction = _provinciaRepository.BeginTransaction();
            try
            {

                provincia entity= _mapper.Map<provincia>(newprovincia);
                var addedprovincia = await _provinciaRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<provinciaResponse>(addedprovincia);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id, string externalUserId)
        {
            var transaction = _provinciaRepository.BeginTransaction();
            try
            {
                var result = (await _provinciaRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "provincia not found");
                }
                await _provinciaRepository.Delete(result.provinciaId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<provinciaResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<provincia> items = await _provinciaRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<provinciaResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<provinciaResponse> GetById(int id)
        {
            try
            {
                var result = (await _provinciaRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "provincia not found");
                }
                return _mapper.Map<provinciaResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<provinciaResponse> Update(provinciaRequest updatedprovincia, string externalUserId)
        {
            var transaction = _provinciaRepository.BeginTransaction();
            try
            {

                var mappedprovincia = (await _provinciaRepository.Get(updatedprovincia.provinciaId)).FirstOrDefault();
		        var result = await _provinciaRepository.Update(mappedprovincia);
                var mappedResponse = _mapper.Map<provinciaResponse>(result);
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
