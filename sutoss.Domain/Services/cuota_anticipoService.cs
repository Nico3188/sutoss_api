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
    public class cuotas_anticiposService : BaseService, Icuotas_anticiposService
    {
        private readonly Icuota_anticipoRepository _cuota_anticipoRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public cuotas_anticiposService(
            Icuota_anticipoRepository cuota_anticipoRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _cuota_anticipoRepository = cuota_anticipoRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<cuota_anticipoResponse> Create(cuota_anticipoRequest newcuota_anticipo, string externalUserId)
        {
            var transaction = _cuota_anticipoRepository.BeginTransaction();
            try
            {

                cuota_anticipo entity= _mapper.Map<cuota_anticipo>(newcuota_anticipo);
                var addedcuota_anticipo = await _cuota_anticipoRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<cuota_anticipoResponse>(addedcuota_anticipo);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id, string externalUserId)
        {
            var transaction = _cuota_anticipoRepository.BeginTransaction();
            try
            {
                var result = (await _cuota_anticipoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "cuota_anticipo not found");
                }
                await _cuota_anticipoRepository.Delete(result.cuota_anticipoId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<cuota_anticipoResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<cuota_anticipo> items = await _cuota_anticipoRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<cuota_anticipoResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<cuota_anticipoResponse> GetById(int id)
        {
            try
            {
                var result = (await _cuota_anticipoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "cuota_anticipo not found");
                }
                return _mapper.Map<cuota_anticipoResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<cuota_anticipoResponse> Update(cuota_anticipoRequest updatedcuota_anticipo, string externalUserId)
        {
            var transaction = _cuota_anticipoRepository.BeginTransaction();
            try
            {

                var mappedcuota_anticipo = (await _cuota_anticipoRepository.Get(updatedcuota_anticipo.cuota_anticipoId)).FirstOrDefault();
		        var result = await _cuota_anticipoRepository.Update(mappedcuota_anticipo);
                var mappedResponse = _mapper.Map<cuota_anticipoResponse>(result);
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
