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
    public class comprasService : BaseService, IcomprasService
    {
        private readonly IcompraRepository _compraRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public comprasService(
            IcompraRepository compraRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _compraRepository = compraRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<compraResponse> Create(compraRequest newcompra, string externalUserId)
        {
            var transaction = _compraRepository.BeginTransaction();
            try
            {

                compra entity= _mapper.Map<compra>(newcompra);
                var addedcompra = await _compraRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<compraResponse>(addedcompra);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id, string externalUserId)
        {
            var transaction = _compraRepository.BeginTransaction();
            try
            {
                var result = (await _compraRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "compra not found");
                }
                await _compraRepository.Delete(result.compraId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<compraResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<compra> items = await _compraRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<compraResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<compraResponse> GetById(int id)
        {
            try
            {
                var result = (await _compraRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "compra not found");
                }
                return _mapper.Map<compraResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<compraResponse> Update(compraRequest updatedcompra, string externalUserId)
        {
            var transaction = _compraRepository.BeginTransaction();
            try
            {

                var mappedcompra = (await _compraRepository.Get(updatedcompra.compraId)).FirstOrDefault();
		        var result = await _compraRepository.Update(mappedcompra);
                var mappedResponse = _mapper.Map<compraResponse>(result);
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
