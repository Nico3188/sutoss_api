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
    public class MultaService : BaseService, IMultaService
    {
        private readonly IMultumRepository _MultumRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public MultaService(
            IMultumRepository MultumRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _MultumRepository = MultumRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<MultumResponse> Create(MultumRequest newMultum )
        {
            var transaction = _MultumRepository.BeginTransaction();
            try
            {

                Multum entity= _mapper.Map<Multum>(newMultum);
                var addedMultum = await _MultumRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<MultumResponse>(addedMultum);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {
            var transaction = _MultumRepository.BeginTransaction();
            try
            {
                var result = (await _MultumRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Multum not found");
                }
                await _MultumRepository.Delete(result.IdMulta);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<MultumResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<Multum> items = await _MultumRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<MultumResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<MultumResponse> GetById(int id)
        {
            try
            {
                var result = (await _MultumRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Multum not found");
                }
                return _mapper.Map<MultumResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<MultumResponse> Update(MultumRequest updatedMultum )
        {
            var transaction = _MultumRepository.BeginTransaction();
            try
            {

                var mappedMultum = (await _MultumRepository.Get(updatedMultum.IdMulta)).FirstOrDefault();
		        var result = await _MultumRepository.Update(mappedMultum);
                var mappedResponse = _mapper.Map<MultumResponse>(result);
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
