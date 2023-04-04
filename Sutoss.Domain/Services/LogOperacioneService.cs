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
    public class LogOperacionesService : BaseService, ILogOperacionesService
    {
        private readonly ILogOperacioneRepository _LogOperacioneRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public LogOperacionesService(
            ILogOperacioneRepository LogOperacioneRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _LogOperacioneRepository = LogOperacioneRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<LogOperacioneResponse> Create(LogOperacioneRequest newLogOperacione )
        {
            var transaction = _LogOperacioneRepository.BeginTransaction();
            try
            {

                LogOperacione entity= _mapper.Map<LogOperacione>(newLogOperacione);
                var addedLogOperacione = await _LogOperacioneRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<LogOperacioneResponse>(addedLogOperacione);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {
            var transaction = _LogOperacioneRepository.BeginTransaction();
            try
            {
                var result = (await _LogOperacioneRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "LogOperacione not found");
                }
                await _LogOperacioneRepository.Delete(result.IdLogOperaciones);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<LogOperacioneResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<LogOperacione> items = await _LogOperacioneRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<LogOperacioneResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<LogOperacioneResponse> GetById(int id)
        {
            try
            {
                var result = (await _LogOperacioneRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "LogOperacione not found");
                }
                return _mapper.Map<LogOperacioneResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<LogOperacioneResponse> Update(LogOperacioneRequest updatedLogOperacione )
        {
            var transaction = _LogOperacioneRepository.BeginTransaction();
            try
            {

                var mappedLogOperacione = (await _LogOperacioneRepository.Get(updatedLogOperacione.IdLogOperaciones)).FirstOrDefault();
		        var result = await _LogOperacioneRepository.Update(mappedLogOperacione);
                var mappedResponse = _mapper.Map<LogOperacioneResponse>(result);
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
