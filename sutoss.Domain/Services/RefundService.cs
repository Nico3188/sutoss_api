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
    public class RefundsService : BaseService, IRefundsService
    {
        private readonly IRefundRepository _RefundRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public RefundsService(
            IRefundRepository RefundRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _RefundRepository = RefundRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<RefundResponse> Create(RefundRequest newRefund)
        {
            var transaction = _RefundRepository.BeginTransaction();
            try
            {

                Refund entity= _mapper.Map<Refund>(newRefund);
                var addedRefund = await _RefundRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<RefundResponse>(addedRefund);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var transaction = _RefundRepository.BeginTransaction();
            try
            {
                var result = (await _RefundRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Refund not found");
                }
                await _RefundRepository.Delete(result.RefundId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<RefundResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<Refund> items = await _RefundRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<RefundResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<RefundResponse> GetById(int id)
        {
            try
            {
                var result = (await _RefundRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Refund not found");
                }
                return _mapper.Map<RefundResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<RefundResponse> Update(RefundRequest updatedRefund)
        {
            var transaction = _RefundRepository.BeginTransaction();
            try
            {

                var mappedRefund = (await _RefundRepository.Get(updatedRefund.RefundId)).FirstOrDefault();
		        var result = await _RefundRepository.Update(mappedRefund);
                var mappedResponse = _mapper.Map<RefundResponse>(result);
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
