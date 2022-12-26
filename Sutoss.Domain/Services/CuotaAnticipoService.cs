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
    public class CuotaAnticiposService : BaseService, ICuotaAnticiposService
    {
        private readonly ICuotaAnticipoRepository _CuotaAnticipoRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public CuotaAnticiposService(
            ICuotaAnticipoRepository CuotaAnticipoRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _CuotaAnticipoRepository = CuotaAnticipoRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<CuotaAnticipoResponse> Create(CuotaAnticipoRequest newCuotaAnticipo )
        {
            var transaction = _CuotaAnticipoRepository.BeginTransaction();
            try
            {

                CuotaAnticipo entity= _mapper.Map<CuotaAnticipo>(newCuotaAnticipo);
                var addedCuotaAnticipo = await _CuotaAnticipoRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<CuotaAnticipoResponse>(addedCuotaAnticipo);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {
            var transaction = _CuotaAnticipoRepository.BeginTransaction();
            try
            {
                var result = (await _CuotaAnticipoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "CuotaAnticipo not found");
                }
                await _CuotaAnticipoRepository.Delete(result.IdCuotaAnticipo);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<CuotaAnticipoResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<CuotaAnticipo> items = await _CuotaAnticipoRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<CuotaAnticipoResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CuotaAnticipoResponse> GetById(int id)
        {
            try
            {
                var result = (await _CuotaAnticipoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "CuotaAnticipo not found");
                }
                return _mapper.Map<CuotaAnticipoResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CuotaAnticipoResponse> Update(CuotaAnticipoRequest updatedCuotaAnticipo )
        {
            var transaction = _CuotaAnticipoRepository.BeginTransaction();
            try
            {

                var mappedCuotaAnticipo = (await _CuotaAnticipoRepository.Get(updatedCuotaAnticipo.IdCuotaAnticipo)).FirstOrDefault();
		        var result = await _CuotaAnticipoRepository.Update(mappedCuotaAnticipo);
                var mappedResponse = _mapper.Map<CuotaAnticipoResponse>(result);
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
