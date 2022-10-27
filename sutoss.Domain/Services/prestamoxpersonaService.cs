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
    public class pretamosxpersonasService : BaseService, IpretamosxpersonasService
    {
        private readonly IprestamoxpersonaRepository _prestamoxpersonaRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public pretamosxpersonasService(
            IprestamoxpersonaRepository prestamoxpersonaRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _prestamoxpersonaRepository = prestamoxpersonaRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<prestamoxpersonaResponse> Create(prestamoxpersonaRequest newprestamoxpersona, string externalUserId)
        {
            var transaction = _prestamoxpersonaRepository.BeginTransaction();
            try
            {

                prestamoxpersona entity= _mapper.Map<prestamoxpersona>(newprestamoxpersona);
                var addedprestamoxpersona = await _prestamoxpersonaRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<prestamoxpersonaResponse>(addedprestamoxpersona);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id, string externalUserId)
        {
            var transaction = _prestamoxpersonaRepository.BeginTransaction();
            try
            {
                var result = (await _prestamoxpersonaRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "prestamoxpersona not found");
                }
                await _prestamoxpersonaRepository.Delete(result.prestamoxpersonaId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<prestamoxpersonaResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<prestamoxpersona> items = await _prestamoxpersonaRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<prestamoxpersonaResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<prestamoxpersonaResponse> GetById(int id)
        {
            try
            {
                var result = (await _prestamoxpersonaRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "prestamoxpersona not found");
                }
                return _mapper.Map<prestamoxpersonaResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<prestamoxpersonaResponse> Update(prestamoxpersonaRequest updatedprestamoxpersona, string externalUserId)
        {
            var transaction = _prestamoxpersonaRepository.BeginTransaction();
            try
            {

                var mappedprestamoxpersona = (await _prestamoxpersonaRepository.Get(updatedprestamoxpersona.prestamoxpersonaId)).FirstOrDefault();
		        var result = await _prestamoxpersonaRepository.Update(mappedprestamoxpersona);
                var mappedResponse = _mapper.Map<prestamoxpersonaResponse>(result);
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
