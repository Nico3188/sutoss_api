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
    public class productosService : BaseService, IproductosService
    {
        private readonly IproductoRepository _productoRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public productosService(
            IproductoRepository productoRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _productoRepository = productoRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<productoResponse> Create(productoRequest newproducto, string externalUserId)
        {
            var transaction = _productoRepository.BeginTransaction();
            try
            {

                producto entity= _mapper.Map<producto>(newproducto);
                var addedproducto = await _productoRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<productoResponse>(addedproducto);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id, string externalUserId)
        {
            var transaction = _productoRepository.BeginTransaction();
            try
            {
                var result = (await _productoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "producto not found");
                }
                await _productoRepository.Delete(result.productoId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<productoResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<producto> items = await _productoRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<productoResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<productoResponse> GetById(int id)
        {
            try
            {
                var result = (await _productoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "producto not found");
                }
                return _mapper.Map<productoResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<productoResponse> Update(productoRequest updatedproducto, string externalUserId)
        {
            var transaction = _productoRepository.BeginTransaction();
            try
            {

                var mappedproducto = (await _productoRepository.Get(updatedproducto.productoId)).FirstOrDefault();
		        var result = await _productoRepository.Update(mappedproducto);
                var mappedResponse = _mapper.Map<productoResponse>(result);
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
