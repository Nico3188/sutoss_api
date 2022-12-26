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
    public class ConvenioxprovsService : BaseService, IConvenioxprovsService
    {
        private readonly IConvenioxprovRepository _ConvenioxprovRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public ConvenioxprovsService(
            IConvenioxprovRepository ConvenioxprovRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _ConvenioxprovRepository = ConvenioxprovRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<ConvenioxprovResponse> Create(ConvenioxprovRequest newConvenioxprov )
        {
            var transaction = _ConvenioxprovRepository.BeginTransaction();
            try
            {

                Convenioxprov entity= _mapper.Map<Convenioxprov>(newConvenioxprov);
                var addedConvenioxprov = await _ConvenioxprovRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<ConvenioxprovResponse>(addedConvenioxprov);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {
            var transaction = _ConvenioxprovRepository.BeginTransaction();
            try
            {
                var result = (await _ConvenioxprovRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Convenioxprov not found");
                }
                await _ConvenioxprovRepository.Delete(result.IdConvenioxProv); 
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<ConvenioxprovResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<Convenioxprov> items = await _ConvenioxprovRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<ConvenioxprovResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ConvenioxprovResponse> GetById(int id)
        {
            try
            {
                var result = (await _ConvenioxprovRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Convenioxprov not found");
                }
                return _mapper.Map<ConvenioxprovResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ConvenioxprovResponse> Update(ConvenioxprovRequest updatedConvenioxprov )
        {
            var transaction = _ConvenioxprovRepository.BeginTransaction();
            try
            {

                var mappedConvenioxprov = (await _ConvenioxprovRepository.Get(updatedConvenioxprov.IdConvenioxProv)).FirstOrDefault();
		        var result = await _ConvenioxprovRepository.Update(mappedConvenioxprov);
                var mappedResponse = _mapper.Map<ConvenioxprovResponse>(result);
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
