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
    public class DesignacionsService : BaseService, IDesignacionsService
    {
        private readonly IDesignacionRepository _DesignacionRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public DesignacionsService(
            IDesignacionRepository DesignacionRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _DesignacionRepository = DesignacionRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<DesignacionResponse> Create(DesignacionRequest newDesignacion )
        {
            var transaction = _DesignacionRepository.BeginTransaction();
            try
            {

                Designacion entity= _mapper.Map<Designacion>(newDesignacion);
                var addedDesignacion = await _DesignacionRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<DesignacionResponse>(addedDesignacion);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {
            var transaction = _DesignacionRepository.BeginTransaction();
            try
            {
                var result = (await _DesignacionRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Designacion not found");
                }
                await _DesignacionRepository.Delete(result.IdDesignacion);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<DesignacionResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<Designacion> items = await _DesignacionRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<DesignacionResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DesignacionResponse> GetById(int id)
        {
            try
            {
                var result = (await _DesignacionRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Designacion not found");
                }
                return _mapper.Map<DesignacionResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DesignacionResponse> Update(DesignacionRequest updatedDesignacion )
        {
            var transaction = _DesignacionRepository.BeginTransaction();
            try
            {

                var mappedDesignacion = (await _DesignacionRepository.Get(updatedDesignacion.IdDesignacion)).FirstOrDefault();
		        var result = await _DesignacionRepository.Update(mappedDesignacion);
                var mappedResponse = _mapper.Map<DesignacionResponse>(result);
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
