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
    public class EnferemedadsService : BaseService, IEnferemedadsService
    {
        private readonly IEnferemedadRepository _EnferemedadRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public EnferemedadsService(
            IEnferemedadRepository EnferemedadRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _EnferemedadRepository = EnferemedadRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<EnferemedadResponse> Create(EnferemedadRequest newEnferemedad )
        {
            var transaction = _EnferemedadRepository.BeginTransaction();
            try
            {

                Enferemedad entity= _mapper.Map<Enferemedad>(newEnferemedad);
                var addedEnferemedad = await _EnferemedadRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<EnferemedadResponse>(addedEnferemedad);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {
            var transaction = _EnferemedadRepository.BeginTransaction();
            try
            {
                var result = (await _EnferemedadRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Enferemedad not found");
                }
                await _EnferemedadRepository.Delete(result.IdEnferemedad);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<EnferemedadResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<Enferemedad> items = await _EnferemedadRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<EnferemedadResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<EnferemedadResponse> GetById(int id)
        {
            try
            {
                var result = (await _EnferemedadRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Enferemedad not found");
                }
                return _mapper.Map<EnferemedadResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<EnferemedadResponse> Update(EnferemedadRequest updatedEnferemedad )
        {
            var transaction = _EnferemedadRepository.BeginTransaction();
            try
            {

                var mappedEnferemedad = (await _EnferemedadRepository.Get(updatedEnferemedad.IdEnferemedad)).FirstOrDefault();
		        var result = await _EnferemedadRepository.Update(mappedEnferemedad);
                var mappedResponse = _mapper.Map<EnferemedadResponse>(result);
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
