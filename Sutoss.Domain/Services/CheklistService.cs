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
    public class CheklistsService : BaseService, ICheklistsService
    {
        private readonly ICheklistRepository _CheklistRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public CheklistsService(
            ICheklistRepository CheklistRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _CheklistRepository = CheklistRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<CheklistResponse> Create(CheklistRequest newCheklist )
        {
            var transaction = _CheklistRepository.BeginTransaction();
            try
            {

                Cheklist entity= _mapper.Map<Cheklist>(newCheklist);
                var addedCheklist = await _CheklistRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<CheklistResponse>(addedCheklist);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {
            var transaction = _CheklistRepository.BeginTransaction();
            try
            {
                var result = (await _CheklistRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Cheklist not found");
                }
                await _CheklistRepository.Delete(result.IdChecklist);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<CheklistResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<Cheklist> items = await _CheklistRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<CheklistResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CheklistResponse> GetById(int id)
        {
            try
            {
                var result = (await _CheklistRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Cheklist not found");
                }
                return _mapper.Map<CheklistResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CheklistResponse> Update(CheklistRequest updatedCheklist )
        {
            var transaction = _CheklistRepository.BeginTransaction();
            try
            {

                var mappedCheklist = (await _CheklistRepository.Get(updatedCheklist.IdChecklist)).FirstOrDefault();
		        var result = await _CheklistRepository.Update(mappedCheklist);
                var mappedResponse = _mapper.Map<CheklistResponse>(result);
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
