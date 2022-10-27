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
    public class perfilesService : BaseService, IperfilesService
    {
        private readonly IperfilRepository _perfilRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public perfilesService(
            IperfilRepository perfilRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _perfilRepository = perfilRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<perfilResponse> Create(perfilRequest newperfil, string externalUserId)
        {
            var transaction = _perfilRepository.BeginTransaction();
            try
            {

                perfil entity= _mapper.Map<perfil>(newperfil);
                var addedperfil = await _perfilRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<perfilResponse>(addedperfil);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id, string externalUserId)
        {
            var transaction = _perfilRepository.BeginTransaction();
            try
            {
                var result = (await _perfilRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "perfil not found");
                }
                await _perfilRepository.Delete(result.perfilId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<perfilResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<perfil> items = await _perfilRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<perfilResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<perfilResponse> GetById(int id)
        {
            try
            {
                var result = (await _perfilRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "perfil not found");
                }
                return _mapper.Map<perfilResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<perfilResponse> Update(perfilRequest updatedperfil, string externalUserId)
        {
            var transaction = _perfilRepository.BeginTransaction();
            try
            {

                var mappedperfil = (await _perfilRepository.Get(updatedperfil.perfilId)).FirstOrDefault();
		        var result = await _perfilRepository.Update(mappedperfil);
                var mappedResponse = _mapper.Map<perfilResponse>(result);
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
