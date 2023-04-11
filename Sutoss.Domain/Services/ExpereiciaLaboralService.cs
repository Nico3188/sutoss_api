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
    public class ExpereiciaLaboralsService : BaseService, IExpereiciaLaboralsService
    {
        private readonly IExpereiciaLaboralRepository _ExpereiciaLaboralRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public ExpereiciaLaboralsService(
            IExpereiciaLaboralRepository ExpereiciaLaboralRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _ExpereiciaLaboralRepository = ExpereiciaLaboralRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<ExpereiciaLaboralResponse> Create(ExpereiciaLaboralRequest newExpereiciaLaboral )
        {
            var transaction = _ExpereiciaLaboralRepository.BeginTransaction();
            try
            {

                ExpereiciaLaboral entity= _mapper.Map<ExpereiciaLaboral>(newExpereiciaLaboral);
                var addedExpereiciaLaboral = await _ExpereiciaLaboralRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<ExpereiciaLaboralResponse>(addedExpereiciaLaboral);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {
            var transaction = _ExpereiciaLaboralRepository.BeginTransaction();
            try
            {
                var result = (await _ExpereiciaLaboralRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "ExpereiciaLaboral not found");
                }
                await _ExpereiciaLaboralRepository.Delete(result.IdExpereiciaLaboral);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<ExpereiciaLaboralResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<ExpereiciaLaboral> items = await _ExpereiciaLaboralRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<ExpereiciaLaboralResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ExpereiciaLaboralResponse> GetById(int id)
        {
            try
            {
                var result = (await _ExpereiciaLaboralRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "ExpereiciaLaboral not found");
                }
                return _mapper.Map<ExpereiciaLaboralResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ExpereiciaLaboralResponse> Update(ExpereiciaLaboralRequest updatedExpereiciaLaboral )
        {
            var transaction = _ExpereiciaLaboralRepository.BeginTransaction();
            try
            {

                var mappedExpereiciaLaboral = (await _ExpereiciaLaboralRepository.Get(updatedExpereiciaLaboral.IdExpereiciaLaboral)).FirstOrDefault();
		        var result = await _ExpereiciaLaboralRepository.Update(mappedExpereiciaLaboral);
                var mappedResponse = _mapper.Map<ExpereiciaLaboralResponse>(result);
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
