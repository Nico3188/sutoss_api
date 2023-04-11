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
    public class IdiomasService : BaseService, IIdiomasService
    {
        private readonly IIdiomaRepository _IdiomaRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public IdiomasService(
            IIdiomaRepository IdiomaRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _IdiomaRepository = IdiomaRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<IdiomaResponse> Create(IdiomaRequest newIdioma )
        {
            var transaction = _IdiomaRepository.BeginTransaction();
            try
            {

                Idioma entity= _mapper.Map<Idioma>(newIdioma);
                var addedIdioma = await _IdiomaRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<IdiomaResponse>(addedIdioma);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {
            var transaction = _IdiomaRepository.BeginTransaction();
            try
            {
                var result = (await _IdiomaRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Idioma not found");
                }
                await _IdiomaRepository.Delete(result.IdIdioma);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<IdiomaResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<Idioma> items = await _IdiomaRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<IdiomaResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IdiomaResponse> GetById(int id)
        {
            try
            {
                var result = (await _IdiomaRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Idioma not found");
                }
                return _mapper.Map<IdiomaResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IdiomaResponse> Update(IdiomaRequest updatedIdioma )
        {
            var transaction = _IdiomaRepository.BeginTransaction();
            try
            {

                var mappedIdioma = (await _IdiomaRepository.Get(updatedIdioma.IdIdioma)).FirstOrDefault();
		        var result = await _IdiomaRepository.Update(mappedIdioma);
                var mappedResponse = _mapper.Map<IdiomaResponse>(result);
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
