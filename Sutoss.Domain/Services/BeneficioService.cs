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
    public class BeneficiosService : BaseService, IBeneficiosService
    {
        private readonly IBeneficioRepository _BeneficioRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public BeneficiosService(
            IBeneficioRepository BeneficioRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _BeneficioRepository = BeneficioRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<BeneficioResponse> Create(BeneficioRequest newBeneficio )
        {
            var transaction = _BeneficioRepository.BeginTransaction();
            try
            {

                Beneficio entity= _mapper.Map<Beneficio>(newBeneficio);
                var addedBeneficio = await _BeneficioRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<BeneficioResponse>(addedBeneficio);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {
            var transaction = _BeneficioRepository.BeginTransaction();
            try
            {
                var result = (await _BeneficioRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Beneficio not found");
                }
                await _BeneficioRepository.Delete(result.IdBeneficio);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<BeneficioResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<Beneficio> items = await _BeneficioRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<BeneficioResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BeneficioResponse> GetById(int id)
        {
            try
            {
                var result = (await _BeneficioRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Beneficio not found");
                }
                return _mapper.Map<BeneficioResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BeneficioResponse> Update(BeneficioRequest updatedBeneficio )
        {
            var transaction = _BeneficioRepository.BeginTransaction();
            try
            {

                var mappedBeneficio = (await _BeneficioRepository.Get(updatedBeneficio.IdBeneficio)).FirstOrDefault();
		        var result = await _BeneficioRepository.Update(mappedBeneficio);
                var mappedResponse = _mapper.Map<BeneficioResponse>(result);
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
