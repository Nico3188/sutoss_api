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
    public class DiaService : BaseService, IDiaService
    {
        private readonly IDiumRepository _DiumRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public DiaService(
            IDiumRepository DiumRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _DiumRepository = DiumRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<DiumResponse> Create(DiumRequest newDium )
        {
            var transaction = _DiumRepository.BeginTransaction();
            try
            {

                Dium entity= _mapper.Map<Dium>(newDium);
                var addedDium = await _DiumRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<DiumResponse>(addedDium);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {
            var transaction = _DiumRepository.BeginTransaction();
            try
            {
                var result = (await _DiumRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Dium not found");
                }
                await _DiumRepository.Delete(result.IdDia);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<DiumResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<Dium> items = await _DiumRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<DiumResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DiumResponse> GetById(int id)
        {
            try
            {
                var result = (await _DiumRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Dium not found");
                }
                return _mapper.Map<DiumResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DiumResponse> Update(DiumRequest updatedDium )
        {
            var transaction = _DiumRepository.BeginTransaction();
            try
            {

                var mappedDium = (await _DiumRepository.Get(updatedDium.IdDia)).FirstOrDefault();
		        var result = await _DiumRepository.Update(mappedDium);
                var mappedResponse = _mapper.Map<DiumResponse>(result);
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
