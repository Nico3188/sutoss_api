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
    public class PerfilsService : BaseService, IPerfilsService
    {
        private readonly IPerfilRepository _PerfilRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public PerfilsService(
            IPerfilRepository PerfilRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _PerfilRepository = PerfilRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<PerfilResponse> Create(PerfilRequest newPerfil )
        {
            var transaction = _PerfilRepository.BeginTransaction();
            try
            {

                Perfil entity= _mapper.Map<Perfil>(newPerfil);
                var addedPerfil = await _PerfilRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<PerfilResponse>(addedPerfil);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {
            var transaction = _PerfilRepository.BeginTransaction();
            try
            {
                var result = (await _PerfilRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Perfil not found");
                }
                await _PerfilRepository.Delete(result.IdPerfil);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<PerfilResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<Perfil> items = await _PerfilRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<PerfilResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PerfilResponse> GetById(int id)
        {
            try
            {
                var result = (await _PerfilRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Perfil not found");
                }
                return _mapper.Map<PerfilResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PerfilResponse> Update(PerfilRequest updatedPerfil )
        {
            var transaction = _PerfilRepository.BeginTransaction();
            try
            {

                var mappedPerfil = (await _PerfilRepository.Get(updatedPerfil.IdPerfil)).FirstOrDefault();
		        var result = await _PerfilRepository.Update(mappedPerfil);
                var mappedResponse = _mapper.Map<PerfilResponse>(result);
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
