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
    public class diciplinasService : BaseService, IdiciplinasService
    {
        private readonly IdiciplinaRepository _diciplinaRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public diciplinasService(
            IdiciplinaRepository diciplinaRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _diciplinaRepository = diciplinaRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<diciplinaResponse> Create(diciplinaRequest newdiciplina, string externalUserId)
        {
            var transaction = _diciplinaRepository.BeginTransaction();
            try
            {

                diciplina entity= _mapper.Map<diciplina>(newdiciplina);
                var addeddiciplina = await _diciplinaRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<diciplinaResponse>(addeddiciplina);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id, string externalUserId)
        {
            var transaction = _diciplinaRepository.BeginTransaction();
            try
            {
                var result = (await _diciplinaRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "diciplina not found");
                }
                await _diciplinaRepository.Delete(result.diciplinaId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<diciplinaResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<diciplina> items = await _diciplinaRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<diciplinaResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<diciplinaResponse> GetById(int id)
        {
            try
            {
                var result = (await _diciplinaRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "diciplina not found");
                }
                return _mapper.Map<diciplinaResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<diciplinaResponse> Update(diciplinaRequest updateddiciplina, string externalUserId)
        {
            var transaction = _diciplinaRepository.BeginTransaction();
            try
            {

                var mappeddiciplina = (await _diciplinaRepository.Get(updateddiciplina.diciplinaId)).FirstOrDefault();
		        var result = await _diciplinaRepository.Update(mappeddiciplina);
                var mappedResponse = _mapper.Map<diciplinaResponse>(result);
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
