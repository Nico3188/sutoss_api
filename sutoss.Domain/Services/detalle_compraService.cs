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
    public class detalle_comprasService : BaseService, Idetalle_comprasService
    {
        private readonly Idetalle_compraRepository _detalle_compraRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public detalle_comprasService(
            Idetalle_compraRepository detalle_compraRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _detalle_compraRepository = detalle_compraRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<detalle_compraResponse> Create(detalle_compraRequest newdetalle_compra, string externalUserId)
        {
            var transaction = _detalle_compraRepository.BeginTransaction();
            try
            {

                detalle_compra entity= _mapper.Map<detalle_compra>(newdetalle_compra);
                var addeddetalle_compra = await _detalle_compraRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<detalle_compraResponse>(addeddetalle_compra);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id, string externalUserId)
        {
            var transaction = _detalle_compraRepository.BeginTransaction();
            try
            {
                var result = (await _detalle_compraRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "detalle_compra not found");
                }
                await _detalle_compraRepository.Delete(result.detalle_compraId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<detalle_compraResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<detalle_compra> items = await _detalle_compraRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<detalle_compraResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<detalle_compraResponse> GetById(int id)
        {
            try
            {
                var result = (await _detalle_compraRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "detalle_compra not found");
                }
                return _mapper.Map<detalle_compraResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<detalle_compraResponse> Update(detalle_compraRequest updateddetalle_compra, string externalUserId)
        {
            var transaction = _detalle_compraRepository.BeginTransaction();
            try
            {

                var mappeddetalle_compra = (await _detalle_compraRepository.Get(updateddetalle_compra.detalle_compraId)).FirstOrDefault();
		        var result = await _detalle_compraRepository.Update(mappeddetalle_compra);
                var mappedResponse = _mapper.Map<detalle_compraResponse>(result);
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
