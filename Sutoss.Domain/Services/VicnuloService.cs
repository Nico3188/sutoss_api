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
    public class VicnulosService : BaseService, IVicnulosService
    {
        private readonly IVicnuloRepository _VicnuloRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public VicnulosService(
            IVicnuloRepository VicnuloRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _VicnuloRepository = VicnuloRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<VicnuloResponse> Create(VicnuloRequest newVicnulo )
        {
            var transaction = _VicnuloRepository.BeginTransaction();
            try
            {

                Vicnulo entity= _mapper.Map<Vicnulo>(newVicnulo);
                var addedVicnulo = await _VicnuloRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<VicnuloResponse>(addedVicnulo);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {
            var transaction = _VicnuloRepository.BeginTransaction();
            try
            {
                var result = (await _VicnuloRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Vicnulo not found");
                }
                await _VicnuloRepository.Delete(result.IdVicnulo);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<VicnuloResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<Vicnulo> items = await _VicnuloRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<VicnuloResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<VicnuloResponse> GetById(int id)
        {
            try
            {
                var result = (await _VicnuloRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Vicnulo not found");
                }
                return _mapper.Map<VicnuloResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<VicnuloResponse> Update(VicnuloRequest updatedVicnulo )
        {
            var transaction = _VicnuloRepository.BeginTransaction();
            try
            {

                var mappedVicnulo = (await _VicnuloRepository.Get(updatedVicnulo.IdVicnulo)).FirstOrDefault();
		        var result = await _VicnuloRepository.Update(mappedVicnulo);
                var mappedResponse = _mapper.Map<VicnuloResponse>(result);
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
