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
    public class ImpuestosService : BaseService, IImpuestosService
    {
        private readonly IImpuestoRepository _ImpuestoRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public ImpuestosService(
            IImpuestoRepository ImpuestoRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _ImpuestoRepository = ImpuestoRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<ImpuestoResponse> Create(ImpuestoRequest newImpuesto )
        {
            var transaction = _ImpuestoRepository.BeginTransaction();
            try
            {

                Impuesto entity= _mapper.Map<Impuesto>(newImpuesto);
                var addedImpuesto = await _ImpuestoRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<ImpuestoResponse>(addedImpuesto);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {
            var transaction = _ImpuestoRepository.BeginTransaction();
            try
            {
                var result = (await _ImpuestoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Impuesto not found");
                }
                await _ImpuestoRepository.Delete(result.IdImpuseto);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<ImpuestoResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<Impuesto> items = await _ImpuestoRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<ImpuestoResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ImpuestoResponse> GetById(int id)
        {
            try
            {
                var result = (await _ImpuestoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Impuesto not found");
                }
                return _mapper.Map<ImpuestoResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ImpuestoResponse> Update(ImpuestoRequest updatedImpuesto )
        {
            var transaction = _ImpuestoRepository.BeginTransaction();
            try
            {

                var mappedImpuesto = (await _ImpuestoRepository.Get(updatedImpuesto.IdImpuseto)).FirstOrDefault();
		        var result = await _ImpuestoRepository.Update(mappedImpuesto);
                var mappedResponse = _mapper.Map<ImpuestoResponse>(result);
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
