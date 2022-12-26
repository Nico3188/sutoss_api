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
    public class AlquilersService : BaseService, IAlquilersService
    {
        private readonly IAlquilerRepository _AlquilerRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public AlquilersService(
            IAlquilerRepository AlquilerRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _AlquilerRepository = AlquilerRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<AlquilerResponse> Create(AlquilerRequest newAlquiler )
        {
            var transaction = _AlquilerRepository.BeginTransaction();
            try
            {

                Alquiler entity= _mapper.Map<Alquiler>(newAlquiler);
                var addedAlquiler = await _AlquilerRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<AlquilerResponse>(addedAlquiler);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {
            var transaction = _AlquilerRepository.BeginTransaction();
            try
            {
                var result = (await _AlquilerRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Alquiler not found");
                }
                await _AlquilerRepository.Delete(result.IdAlquiler);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<AlquilerResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<Alquiler> items = await _AlquilerRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<AlquilerResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<AlquilerResponse> GetById(int id)
        {
            try
            {
                var result = (await _AlquilerRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Alquiler not found");
                }
                return _mapper.Map<AlquilerResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<AlquilerResponse> Update(AlquilerRequest updatedAlquiler )
        {
            var transaction = _AlquilerRepository.BeginTransaction();
            try
            {

                var mappedAlquiler = (await _AlquilerRepository.Get(updatedAlquiler.IdAlquiler)).FirstOrDefault();
		        var result = await _AlquilerRepository.Update(mappedAlquiler);
                var mappedResponse = _mapper.Map<AlquilerResponse>(result);
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
