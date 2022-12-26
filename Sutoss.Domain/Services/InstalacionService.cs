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
    public class InstalacionsService : BaseService, IInstalacionsService
    {
        private readonly IInstalacionRepository _InstalacionRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public InstalacionsService(
            IInstalacionRepository InstalacionRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _InstalacionRepository = InstalacionRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<InstalacionResponse> Create(InstalacionRequest newInstalacion )
        {
            var transaction = _InstalacionRepository.BeginTransaction();
            try
            {

                Instalacion entity= _mapper.Map<Instalacion>(newInstalacion);
                var addedInstalacion = await _InstalacionRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<InstalacionResponse>(addedInstalacion);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {
            var transaction = _InstalacionRepository.BeginTransaction();
            try
            {
                var result = (await _InstalacionRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Instalacion not found");
                }
                await _InstalacionRepository.Delete(result.IdInstalacion);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<InstalacionResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<Instalacion> items = await _InstalacionRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<InstalacionResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<InstalacionResponse> GetById(int id)
        {
            try
            {
                var result = (await _InstalacionRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Instalacion not found");
                }
                return _mapper.Map<InstalacionResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<InstalacionResponse> Update(InstalacionRequest updatedInstalacion )
        {
            var transaction = _InstalacionRepository.BeginTransaction();
            try
            {

                var mappedInstalacion = (await _InstalacionRepository.Get(updatedInstalacion.IdInstalacion)).FirstOrDefault();
		        var result = await _InstalacionRepository.Update(mappedInstalacion);
                var mappedResponse = _mapper.Map<InstalacionResponse>(result);
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
