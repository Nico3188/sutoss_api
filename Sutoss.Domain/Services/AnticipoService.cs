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
    public class AnticiposService : BaseService, IAnticiposService
    {
        private readonly IAnticipoRepository _AnticipoRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public AnticiposService(
            IAnticipoRepository AnticipoRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _AnticipoRepository = AnticipoRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<AnticipoResponse> Create(AnticipoRequest newAnticipo )
        {
            var transaction = _AnticipoRepository.BeginTransaction();
            try
            {

                Anticipo entity= _mapper.Map<Anticipo>(newAnticipo);
                var addedAnticipo = await _AnticipoRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<AnticipoResponse>(addedAnticipo);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {
            var transaction = _AnticipoRepository.BeginTransaction();
            try
            {
                var result = (await _AnticipoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Anticipo not found");
                }
                await _AnticipoRepository.Delete(result.IdAnticipo);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<AnticipoResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<Anticipo> items = await _AnticipoRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<AnticipoResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<AnticipoResponse> GetById(int id)
        {
            try
            {
                var result = (await _AnticipoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Anticipo not found");
                }
                return _mapper.Map<AnticipoResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<AnticipoResponse> Update(AnticipoRequest updatedAnticipo )
        {
            var transaction = _AnticipoRepository.BeginTransaction();
            try
            {

                var mappedAnticipo = (await _AnticipoRepository.Get(updatedAnticipo.IdAnticipo)).FirstOrDefault();
		        var result = await _AnticipoRepository.Update(mappedAnticipo);
                var mappedResponse = _mapper.Map<AnticipoResponse>(result);
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
