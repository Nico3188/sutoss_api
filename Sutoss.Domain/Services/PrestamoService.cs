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
    public class PrestamosService : BaseService, IPrestamosService
    {
        private readonly IPrestamoRepository _PrestamoRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public PrestamosService(
            IPrestamoRepository PrestamoRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _PrestamoRepository = PrestamoRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<PrestamoResponse> Create(PrestamoRequest newPrestamo )
        {
            var transaction = _PrestamoRepository.BeginTransaction();
            try
            {

                Prestamo entity= _mapper.Map<Prestamo>(newPrestamo);
                var addedPrestamo = await _PrestamoRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<PrestamoResponse>(addedPrestamo);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {
            var transaction = _PrestamoRepository.BeginTransaction();
            try
            {
                var result = (await _PrestamoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Prestamo not found");
                }
                await _PrestamoRepository.Delete(result.IdPrestamo);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<PrestamoResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<Prestamo> items = await _PrestamoRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<PrestamoResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PrestamoResponse> GetById(int id)
        {
            try
            {
                var result = (await _PrestamoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Prestamo not found");
                }
                return _mapper.Map<PrestamoResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PrestamoResponse> Update(PrestamoRequest updatedPrestamo )
        {
            var transaction = _PrestamoRepository.BeginTransaction();
            try
            {

                var mappedPrestamo = (await _PrestamoRepository.Get(updatedPrestamo.IdPrestamo)).FirstOrDefault();
		        var result = await _PrestamoRepository.Update(mappedPrestamo);
                var mappedResponse = _mapper.Map<PrestamoResponse>(result);
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
