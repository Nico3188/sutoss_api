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
    public class ImpxinstalacionsService : BaseService, IImpxinstalacionsService
    {
        private readonly IImpxinstalacionRepository _ImpxinstalacionRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public ImpxinstalacionsService(
            IImpxinstalacionRepository ImpxinstalacionRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _ImpxinstalacionRepository = ImpxinstalacionRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<ImpxinstalacionResponse> Create(ImpxinstalacionRequest newImpxinstalacion )
        {
            var transaction = _ImpxinstalacionRepository.BeginTransaction();
            try
            {

                Impxinstalacion entity= _mapper.Map<Impxinstalacion>(newImpxinstalacion);
                var addedImpxinstalacion = await _ImpxinstalacionRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<ImpxinstalacionResponse>(addedImpxinstalacion);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {
            var transaction = _ImpxinstalacionRepository.BeginTransaction();
            try
            {
                var result = (await _ImpxinstalacionRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Impxinstalacion not found");
                }
                await _ImpxinstalacionRepository.Delete(result.IdIMpxinstalacion);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<ImpxinstalacionResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<Impxinstalacion> items = await _ImpxinstalacionRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<ImpxinstalacionResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ImpxinstalacionResponse> GetById(int id)
        {
            try
            {
                var result = (await _ImpxinstalacionRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Impxinstalacion not found");
                }
                return _mapper.Map<ImpxinstalacionResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ImpxinstalacionResponse> Update(ImpxinstalacionRequest updatedImpxinstalacion )
        {
            var transaction = _ImpxinstalacionRepository.BeginTransaction();
            try
            {

                var mappedImpxinstalacion = (await _ImpxinstalacionRepository.Get(updatedImpxinstalacion.IdIMpxinstalacion)).FirstOrDefault();
		        var result = await _ImpxinstalacionRepository.Update(mappedImpxinstalacion);
                var mappedResponse = _mapper.Map<ImpxinstalacionResponse>(result);
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
