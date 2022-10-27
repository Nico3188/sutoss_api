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
    public class PaymentsService : BaseService, IPaymentsService
    {
        private readonly IPaymentRepository _PaymentRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public PaymentsService(
            IPaymentRepository PaymentRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _PaymentRepository = PaymentRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public async Task<PaymentResponse> Create(PaymentRequest newPayment)
        {
            var transaction = _PaymentRepository.BeginTransaction();
            try
            {

                Payment entity= _mapper.Map<Payment>(newPayment);
                var addedPayment = await _PaymentRepository.Insert(entity);
                transaction.Commit();
                return _mapper.Map<PaymentResponse>(addedPayment);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var transaction = _PaymentRepository.BeginTransaction();
            try
            {
                var result = (await _PaymentRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Payment not found");
                }
                await _PaymentRepository.Delete(result.PaymentId);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<PaymentResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<Payment> items = await _PaymentRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<PaymentResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PaymentResponse> GetById(int id)
        {
            try
            {
                var result = (await _PaymentRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Payment not found");
                }
                return _mapper.Map<PaymentResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PaymentResponse> Update(PaymentRequest updatedPayment)
        {
            var transaction = _PaymentRepository.BeginTransaction();
            try
            {

                var mappedPayment = (await _PaymentRepository.Get(updatedPayment.PaymentId)).FirstOrDefault();
		        var result = await _PaymentRepository.Update(mappedPayment);
                var mappedResponse = _mapper.Map<PaymentResponse>(result);
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
