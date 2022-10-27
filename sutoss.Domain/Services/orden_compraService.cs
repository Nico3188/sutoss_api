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
    public class ordenes_compraService : BaseService, Iordenes_compraService
    {
        private readonly Iorden_compraRepository _orden_compraRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public ordenes_compraService(
            Iorden_compraRepository orden_compraRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _orden_compraRepository = orden_compraRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<orden_compraResponse> Create(orden_compraRequest neworden_compra, string externalUserId)
        {
            var transaction = _orden_compraRepository.BeginTransaction();
            try
            {

                orden_compra entity= _mapper.Map<orden_compra>(neworden_compra);
                var addedorden_compra = await _orden_compraRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<orden_compraResponse>(addedorden_compra);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id, string externalUserId)
        {
            var transaction = _orden_compraRepository.BeginTransaction();
            try
            {
                var result = (await _orden_compraRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "orden_compra not found");
                }
                await _orden_compraRepository.Delete(result.orden_compraId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<orden_compraResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<orden_compra> items = await _orden_compraRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<orden_compraResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<orden_compraResponse> GetById(int id)
        {
            try
            {
                var result = (await _orden_compraRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "orden_compra not found");
                }
                return _mapper.Map<orden_compraResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<orden_compraResponse> Update(orden_compraRequest updatedorden_compra, string externalUserId)
        {
            var transaction = _orden_compraRepository.BeginTransaction();
            try
            {

                var mappedorden_compra = (await _orden_compraRepository.Get(updatedorden_compra.orden_compraId)).FirstOrDefault();
		        var result = await _orden_compraRepository.Update(mappedorden_compra);
                var mappedResponse = _mapper.Map<orden_compraResponse>(result);
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
