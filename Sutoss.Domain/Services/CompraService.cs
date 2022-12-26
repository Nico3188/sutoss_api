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
    public class ComprasService : BaseService, IComprasService
    {
        private readonly ICompraRepository _CompraRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public ComprasService(
            ICompraRepository CompraRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _CompraRepository = CompraRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<CompraResponse> Create(CompraRequest newCompra )
        {
            var transaction = _CompraRepository.BeginTransaction();
            try
            {

                Compra entity= _mapper.Map<Compra>(newCompra);
                var addedCompra = await _CompraRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<CompraResponse>(addedCompra);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {
            var transaction = _CompraRepository.BeginTransaction();
            try
            {
                var result = (await _CompraRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Compra not found");
                }
                await _CompraRepository.Delete(result.IdCompra);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<CompraResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<Compra> items = await _CompraRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<CompraResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CompraResponse> GetById(int id)
        {
            try
            {
                var result = (await _CompraRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Compra not found");
                }
                return _mapper.Map<CompraResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CompraResponse> Update(CompraRequest updatedCompra )
        {
            var transaction = _CompraRepository.BeginTransaction();
            try
            {

                var mappedCompra = (await _CompraRepository.Get(updatedCompra.IdCompra)).FirstOrDefault();
		        var result = await _CompraRepository.Update(mappedCompra);
                var mappedResponse = _mapper.Map<CompraResponse>(result);
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
