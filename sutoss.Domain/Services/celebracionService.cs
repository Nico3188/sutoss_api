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
    public class celebracionesService : BaseService, IcelebracionesService
    {
        private readonly IcelebracionRepository _celebracionRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public celebracionesService(
            IcelebracionRepository celebracionRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _celebracionRepository = celebracionRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<celebracionResponse> Create(celebracionRequest newcelebracion, string externalUserId)
        {
            var transaction = _celebracionRepository.BeginTransaction();
            try
            {

                celebracion entity= _mapper.Map<celebracion>(newcelebracion);
                var addedcelebracion = await _celebracionRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<celebracionResponse>(addedcelebracion);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id, string externalUserId)
        {
            var transaction = _celebracionRepository.BeginTransaction();
            try
            {
                var result = (await _celebracionRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "celebracion not found");
                }
                await _celebracionRepository.Delete(result.celebracionId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<celebracionResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<celebracion> items = await _celebracionRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<celebracionResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<celebracionResponse> GetById(int id)
        {
            try
            {
                var result = (await _celebracionRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "celebracion not found");
                }
                return _mapper.Map<celebracionResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<celebracionResponse> Update(celebracionRequest updatedcelebracion, string externalUserId)
        {
            var transaction = _celebracionRepository.BeginTransaction();
            try
            {

                var mappedcelebracion = (await _celebracionRepository.Get(updatedcelebracion.celebracionId)).FirstOrDefault();
		        var result = await _celebracionRepository.Update(mappedcelebracion);
                var mappedResponse = _mapper.Map<celebracionResponse>(result);
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
