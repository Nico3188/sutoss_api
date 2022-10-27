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
    public class enfermedadesService : BaseService, IenfermedadesService
    {
        private readonly IenfermedadRepository _enfermedadRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public enfermedadesService(
            IenfermedadRepository enfermedadRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _enfermedadRepository = enfermedadRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<enfermedadResponse> Create(enfermedadRequest newenfermedad, string externalUserId)
        {
            var transaction = _enfermedadRepository.BeginTransaction();
            try
            {

                enfermedad entity= _mapper.Map<enfermedad>(newenfermedad);
                var addedenfermedad = await _enfermedadRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<enfermedadResponse>(addedenfermedad);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id, string externalUserId)
        {
            var transaction = _enfermedadRepository.BeginTransaction();
            try
            {
                var result = (await _enfermedadRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "enfermedad not found");
                }
                await _enfermedadRepository.Delete(result.enfermedadId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<enfermedadResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<enfermedad> items = await _enfermedadRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<enfermedadResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<enfermedadResponse> GetById(int id)
        {
            try
            {
                var result = (await _enfermedadRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "enfermedad not found");
                }
                return _mapper.Map<enfermedadResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<enfermedadResponse> Update(enfermedadRequest updatedenfermedad, string externalUserId)
        {
            var transaction = _enfermedadRepository.BeginTransaction();
            try
            {

                var mappedenfermedad = (await _enfermedadRepository.Get(updatedenfermedad.enfermedadId)).FirstOrDefault();
		        var result = await _enfermedadRepository.Update(mappedenfermedad);
                var mappedResponse = _mapper.Map<enfermedadResponse>(result);
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
