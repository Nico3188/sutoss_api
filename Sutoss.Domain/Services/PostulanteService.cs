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
    public class PostulantesService : BaseService, IPostulantesService
    {
        private readonly IPostulanteRepository _PostulanteRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public PostulantesService(
            IPostulanteRepository PostulanteRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _PostulanteRepository = PostulanteRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<PostulanteResponse> Create(PostulanteRequest newPostulante )
        {
            var transaction = _PostulanteRepository.BeginTransaction();
            try
            {

                Postulante entity= _mapper.Map<Postulante>(newPostulante);
                var addedPostulante = await _PostulanteRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<PostulanteResponse>(addedPostulante);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {
            var transaction = _PostulanteRepository.BeginTransaction();
            try
            {
                var result = (await _PostulanteRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Postulante not found");
                }
                await _PostulanteRepository.Delete(result.IdPostulante);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<PostulanteResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<Postulante> items = await _PostulanteRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<PostulanteResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PostulanteResponse> GetById(int id)
        {
            try
            {
                var result = (await _PostulanteRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Postulante not found");
                }
                return _mapper.Map<PostulanteResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PostulanteResponse> Update(PostulanteRequest updatedPostulante )
        {
            var transaction = _PostulanteRepository.BeginTransaction();
            try
            {

                var mappedPostulante = (await _PostulanteRepository.Get(updatedPostulante.IdPostulante)).FirstOrDefault();
		        var result = await _PostulanteRepository.Update(mappedPostulante);
                var mappedResponse = _mapper.Map<PostulanteResponse>(result);
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