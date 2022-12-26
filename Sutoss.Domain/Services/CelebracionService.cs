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
    public class CelebracionsService : BaseService, ICelebracionsService
    {
        private readonly ICelebracionRepository _CelebracionRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public CelebracionsService(
            ICelebracionRepository CelebracionRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _CelebracionRepository = CelebracionRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<CelebracionResponse> Create(CelebracionRequest newCelebracion )
        {
            var transaction = _CelebracionRepository.BeginTransaction();
            try
            {

                Celebracion entity= _mapper.Map<Celebracion>(newCelebracion);
                var addedCelebracion = await _CelebracionRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<CelebracionResponse>(addedCelebracion);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {
            var transaction = _CelebracionRepository.BeginTransaction();
            try
            {
                var result = (await _CelebracionRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Celebracion not found");
                }
                await _CelebracionRepository.Delete(result.IdCelebracion);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<CelebracionResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<Celebracion> items = await _CelebracionRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<CelebracionResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CelebracionResponse> GetById(int id)
        {
            try
            {
                var result = (await _CelebracionRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Celebracion not found");
                }
                return _mapper.Map<CelebracionResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CelebracionResponse> Update(CelebracionRequest updatedCelebracion )
        {
            var transaction = _CelebracionRepository.BeginTransaction();
            try
            {

                var mappedCelebracion = (await _CelebracionRepository.Get(updatedCelebracion.IdCelebracion)).FirstOrDefault();
		        var result = await _CelebracionRepository.Update(mappedCelebracion);
                var mappedResponse = _mapper.Map<CelebracionResponse>(result);
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
