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
    public class GastosService : BaseService, IGastosService
    {
        private readonly IGastoRepository _GastoRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public GastosService(
            IGastoRepository GastoRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _GastoRepository = GastoRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<GastoResponse> Create(GastoRequest newGasto )
        {
            var transaction = _GastoRepository.BeginTransaction();
            try
            {

                Gasto entity= _mapper.Map<Gasto>(newGasto);
                var addedGasto = await _GastoRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<GastoResponse>(addedGasto);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {
            var transaction = _GastoRepository.BeginTransaction();
            try
            {
                var result = (await _GastoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Gasto not found");
                }
                await _GastoRepository.Delete(result.IdGasto);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<GastoResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<Gasto> items = await _GastoRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<GastoResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GastoResponse> GetById(int id)
        {
            try
            {
                var result = (await _GastoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Gasto not found");
                }
                return _mapper.Map<GastoResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GastoResponse> Update(GastoRequest updatedGasto )
        {
            var transaction = _GastoRepository.BeginTransaction();
            try
            {

                var mappedGasto = (await _GastoRepository.Get(updatedGasto.IdGasto)).FirstOrDefault();
		        var result = await _GastoRepository.Update(mappedGasto);
                var mappedResponse = _mapper.Map<GastoResponse>(result);
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
