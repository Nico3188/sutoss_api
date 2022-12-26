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
    public class DiciplinasService : BaseService, IDiciplinasService
    {
        private readonly IDiciplinaRepository _DiciplinaRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public DiciplinasService(
            IDiciplinaRepository DiciplinaRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _DiciplinaRepository = DiciplinaRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<DiciplinaResponse> Create(DiciplinaRequest newDiciplina )
        {
            var transaction = _DiciplinaRepository.BeginTransaction();
            try
            {

                Diciplina entity= _mapper.Map<Diciplina>(newDiciplina);
                var addedDiciplina = await _DiciplinaRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<DiciplinaResponse>(addedDiciplina);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {
            var transaction = _DiciplinaRepository.BeginTransaction();
            try
            {
                var result = (await _DiciplinaRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Diciplina not found");
                }
                await _DiciplinaRepository.Delete(result.IdDiciplina);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<DiciplinaResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<Diciplina> items = await _DiciplinaRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<DiciplinaResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DiciplinaResponse> GetById(int id)
        {
            try
            {
                var result = (await _DiciplinaRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Diciplina not found");
                }
                return _mapper.Map<DiciplinaResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DiciplinaResponse> Update(DiciplinaRequest updatedDiciplina )
        {
            var transaction = _DiciplinaRepository.BeginTransaction();
            try
            {

                var mappedDiciplina = (await _DiciplinaRepository.Get(updatedDiciplina.IdDiciplina)).FirstOrDefault();
		        var result = await _DiciplinaRepository.Update(mappedDiciplina);
                var mappedResponse = _mapper.Map<DiciplinaResponse>(result);
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
