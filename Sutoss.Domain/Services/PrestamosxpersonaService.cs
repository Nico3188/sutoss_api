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
    public class PrestamosxpersonasService : BaseService, IPrestamosxpersonasService
    {
        private readonly IPrestamosxpersonaRepository _PrestamosxpersonaRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public PrestamosxpersonasService(
            IPrestamosxpersonaRepository PrestamosxpersonaRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _PrestamosxpersonaRepository = PrestamosxpersonaRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<PrestamosxpersonaResponse> Create(PrestamosxpersonaRequest newPrestamosxpersona )
        {
            var transaction = _PrestamosxpersonaRepository.BeginTransaction();
            try
            {

                Prestamosxpersona entity= _mapper.Map<Prestamosxpersona>(newPrestamosxpersona);
                var addedPrestamosxpersona = await _PrestamosxpersonaRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<PrestamosxpersonaResponse>(addedPrestamosxpersona);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {
            var transaction = _PrestamosxpersonaRepository.BeginTransaction();
            try
            {
                var result = (await _PrestamosxpersonaRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Prestamosxpersona not found");
                }
                await _PrestamosxpersonaRepository.Delete(result.IdPrestamosxpersona);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<PrestamosxpersonaResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<Prestamosxpersona> items = await _PrestamosxpersonaRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<PrestamosxpersonaResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PrestamosxpersonaResponse> GetById(int id)
        {
            try
            {
                var result = (await _PrestamosxpersonaRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Prestamosxpersona not found");
                }
                return _mapper.Map<PrestamosxpersonaResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PrestamosxpersonaResponse> Update(PrestamosxpersonaRequest updatedPrestamosxpersona )
        {
            var transaction = _PrestamosxpersonaRepository.BeginTransaction();
            try
            {

                var mappedPrestamosxpersona = (await _PrestamosxpersonaRepository.Get(updatedPrestamosxpersona.IdPrestamosxpersona)).FirstOrDefault();
		        var result = await _PrestamosxpersonaRepository.Update(mappedPrestamosxpersona);
                var mappedResponse = _mapper.Map<PrestamosxpersonaResponse>(result);
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
