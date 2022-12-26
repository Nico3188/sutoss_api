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
    public class FormaPagosService : BaseService, IFormaPagosService
    {
        private readonly IFormaPagoRepository _FormaPagoRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public FormaPagosService(
            IFormaPagoRepository FormaPagoRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _FormaPagoRepository = FormaPagoRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<FormaPagoResponse> Create(FormaPagoRequest newFormaPago )
        {
            var transaction = _FormaPagoRepository.BeginTransaction();
            try
            {

                FormaPago entity= _mapper.Map<FormaPago>(newFormaPago);
                var addedFormaPago = await _FormaPagoRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<FormaPagoResponse>(addedFormaPago);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {
            var transaction = _FormaPagoRepository.BeginTransaction();
            try
            {
                var result = (await _FormaPagoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "FormaPago not found");
                }
                await _FormaPagoRepository.Delete(result.IdFormaPago);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<FormaPagoResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<FormaPago> items = await _FormaPagoRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<FormaPagoResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<FormaPagoResponse> GetById(int id)
        {
            try
            {
                var result = (await _FormaPagoRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "FormaPago not found");
                }
                return _mapper.Map<FormaPagoResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<FormaPagoResponse> Update(FormaPagoRequest updatedFormaPago )
        {
            var transaction = _FormaPagoRepository.BeginTransaction();
            try
            {

                var mappedFormaPago = (await _FormaPagoRepository.Get(updatedFormaPago.IdFormaPago)).FirstOrDefault();
		        var result = await _FormaPagoRepository.Update(mappedFormaPago);
                var mappedResponse = _mapper.Map<FormaPagoResponse>(result);
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
