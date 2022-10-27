using AutoMapper;
using sutoss.Domain.Services.Domain.Filters;
using sutoss.Domain.Services.Domain.Repositories.Interfaces;
using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Response;
using sutoss.Domain.Services.Domain.Services.Base;
using sutoss.Domain.Services.Domain.Services.Interfaces;
using sutoss.Domain.Services.Exceptions;
using sutoss.Domain.Services.Helpers;
using sutoss.Domain.Services.Repositories;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace sutoss.Domain.Services.Domain.Services
{
    public class turnosService : BaseService, IturnosService
    {
        private readonly IturnoRepository _turnoRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public turnosService(
            IturnoRepository turnoRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _turnoRepository = turnoRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<turnoResponse> Create(turnoRequest newturno, string externalUserId)
        {
            var transaction = _turnoRepository.BeginTransaction();
            try
            {

                turno entity= _mapper.Map<turno>(newturno);
                var addedturno = await _turnoRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<turnoResponse>(addedturno);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id, string externalUserId)
        {
            var transaction = _turnoRepository.BeginTransaction();
            try
            {
                var result = (await _turnoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "turno not found");
                }
                await _turnoRepository.Delete(result.turnoId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<turnoResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<turno> items = await _turnoRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<turnoResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<turnoResponse> GetById(int id)
        {
            try
            {
                var result = (await _turnoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "turno not found");
                }
                return _mapper.Map<turnoResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<turnoResponse> Update(turnoRequest updatedturno, string externalUserId)
        {
            var transaction = _turnoRepository.BeginTransaction();
            try
            {

                var mappedturno = (await _turnoRepository.Get(updatedturno.turnoId)).FirstOrDefault();
		        var result = await _turnoRepository.Update(mappedturno);
                var mappedResponse = _mapper.Map<turnoResponse>(result);
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
