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
    public class alquileresService : BaseService, IalquileresService
    {
        private readonly IalquilerRepository _alquilerRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public alquileresService(
            IalquilerRepository alquilerRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _alquilerRepository = alquilerRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<alquilerResponse> Create(alquilerRequest newalquiler, string externalUserId)
        {
            var transaction = _alquilerRepository.BeginTransaction();
            try
            {

                alquiler entity= _mapper.Map<alquiler>(newalquiler);
                var addedalquiler = await _alquilerRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<alquilerResponse>(addedalquiler);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id, string externalUserId)
        {
            var transaction = _alquilerRepository.BeginTransaction();
            try
            {
                var result = (await _alquilerRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "alquiler not found");
                }
                await _alquilerRepository.Delete(result.alquilerId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<alquilerResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<alquiler> items = await _alquilerRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<alquilerResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<alquilerResponse> GetById(int id)
        {
            try
            {
                var result = (await _alquilerRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "alquiler not found");
                }
                return _mapper.Map<alquilerResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<alquilerResponse> Update(alquilerRequest updatedalquiler, string externalUserId)
        {
            var transaction = _alquilerRepository.BeginTransaction();
            try
            {

                var mappedalquiler = (await _alquilerRepository.Get(updatedalquiler.alquilerId)).FirstOrDefault();
		        var result = await _alquilerRepository.Update(mappedalquiler);
                var mappedResponse = _mapper.Map<alquilerResponse>(result);
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
