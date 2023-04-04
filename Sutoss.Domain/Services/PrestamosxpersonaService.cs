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
using Microsoft.EntityFrameworkCore;

namespace Sutoss.Domain.Services.Domain.Services
{
    public class PrestamosxpersonasService : BaseService, IPrestamosxpersonasService
    {
        private readonly IPersonaRepository _PersonaRepository;
        private readonly IPrestamosxpersonaRepository _PrestamosxpersonaRepository;
        private readonly IPrestamoRepository _PrestamosRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;

        public PrestamosxpersonasService(
            IPersonaRepository PersonaRepository,
            IPrestamoRepository PrestamosRepository,
            IPrestamosxpersonaRepository PrestamosxpersonaRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _PersonaRepository = PersonaRepository;
            _PrestamosRepository = PrestamosRepository;
            _PrestamosxpersonaRepository = PrestamosxpersonaRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }

        public async Task<PrestamosxpersonaResponse> Create(PrestamosxpersonaRequest newPrestamosxpersona )
        {
            var transaction = _PrestamosxpersonaRepository.BeginTransaction();
            try
            {
                //buscar el id del afiliaido
                
                //var persona = (await _PersonaRepository.GetAll()).Where(x=>x.PerNafiliadio==Prestamosxpersona.PersonaIdPersona).FirstOrDefault();
                Prestamosxpersona Prestamosxpersona =_mapper.Map<Prestamosxpersona>(newPrestamosxpersona);
                var persona = (await _PersonaRepository.All()).FirstOrDefault(x=>x.PerNafiliadio==Prestamosxpersona.PersonaIdPersona);
                if (persona==null){
                    throw new NotFoundException ("No se registra el usuario con numero de legajo" + persona.PerNafiliadio );
                }
                Prestamo prestamo = new Prestamo {
                        PreMonto = newPrestamosxpersona.PreMonto,
                        PreInteres = newPrestamosxpersona.PreInteres,
                        PreEstado = newPrestamosxpersona.PreEstado
                };
                prestamo = await _PrestamosRepository.Insert(prestamo);
                
                //Prestamosxpersona Prestamosxpersona =_mapper.Map<Prestamosxpersona>(newPrestamosxpersona);
                Prestamosxpersona.PrestamoIdPrestamo = prestamo.IdPrestamo;
                Prestamosxpersona.PersonaIdPersona = persona.PerNafiliadio;
                Prestamosxpersona = await _PrestamosxpersonaRepository.Insert(Prestamosxpersona);
                transaction.Commit();
                return _mapper.Map<PrestamosxpersonaResponse>(Prestamosxpersona);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }


        public async Task<bool> Delete(int id )
        {
            var transaction = _PrestamosxpersonaRepository.BeginTransaction();
            try
            {
                var result = (await _PrestamosxpersonaRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Prestamosxpersona not found");
                }
                await _PrestamosxpersonaRepository.Delete(result.IdPrestamosxpersona);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }
        //Modificado
        
        // public async Task<List<PrestamosxpersonaResponse>> GetAll(int? s, int? l, string q)
        // {
        //     int aux;
        //     Persona persona = new Persona();
        //     try
        //     {
        //         if (int.TryParse(q,out aux)==true){
        //             persona = (await _PersonaRepository.All()).FirstOrDefault(x=>x.PerNafiliadio==aux);
        //         }else if (q!=null){
        //             persona = (await _PersonaRepository.All()).FirstOrDefault(x=>x.PerNombre==q);
        //         }

        //         if(persona.IdPersona==0 || persona==null){
        //             s = s != null && s.Value != 0 ? s.Value - 1 : 0;
        //             l = l ?? 10;
        //             IQueryable<Prestamosxpersona> items = await _PrestamosxpersonaRepository.All();
        //             items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
        //             return _mapper.Map<List<PrestamosxpersonaResponse>>(items);                
        //             }
        //         else {
        //           var items =(await _PrestamosxpersonaRepository.All()).FirstOrDefault(x=> x.PersonaIdPersona==persona.IdPersona);
        //           return _mapper.Map<List<PrestamosxpersonaResponse>>(items);  
        //         }
        //         //s = s != null && s.Value != 0 ? s.Value - 1 : 0;
        //         //l = l ?? 10;
        //         //IQueryable<Prestamosxpersona> items = await _PrestamosxpersonaRepository.All();
        //         //var result = (await _PrestamosxpersonaRepository.All()).FirstOrDefault(x=> x.PersonaIdPersona==persona.PersonaIdPersona);
        //         //var items =(await _PrestamosxpersonaRepository.All()).FirstOrDefault(x=> x.PersonaIdPersona==persona.PersonaIdPersona);
        //         //items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
        //         //return _mapper.Map<List<PrestamosxpersonaResponse>>(items);
        //     }
        //     catch (Exception ex)
        //     {
        //         //throw new NotFoundException(message: "Prestamosxpersona not found");
        //         throw ex;
        //     }
        // }

        public async Task<List<PrestamosxpersonaResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 10;
                IQueryable<Prestamosxpersona> items = (await _PrestamosxpersonaRepository.All()).Include(x=>x.PersonaIdPersonaNavigation).Include(x=>x.PrestamoIdPrestamoNavigation);
                
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<PrestamosxpersonaResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Original        
        // public async Task<List<PrestamosxpersonaResponse>> GetAll(int? s, int? l, string q)
        // {
        //     try
        //     {
        //         s = s != null && s.Value != 0 ? s.Value - 1 : 0;
        //         l = l ?? 10;
        //         IQueryable<Prestamosxpersona> items = await _PrestamosxpersonaRepository.All();
        //         items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
        //         return _mapper.Map<List<PrestamosxpersonaResponse>>(items);
        //     }
        //     catch (Exception ex)
        //     {
        //         throw ex;
        //     }
        // }

        public async Task<PrestamosxpersonaResponse> GetById(int id)
        {
            try
            {
                var result = (await _PrestamosxpersonaRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Prestamosxpersona not found");
                }
                return _mapper.Map<PrestamosxpersonaResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PrestamosxpersonaResponse> Update(PrestamosxpersonaRequest updatedPrestamosxpersona )
        {
            var transaction = _PrestamosxpersonaRepository.BeginTransaction();
            try
            {

                var mappedPrestamosxpersona = (await _PrestamosxpersonaRepository.Get(updatedPrestamosxpersona.IdPrestamosxpersona)).FirstOrDefault();
		        var result = await _PrestamosxpersonaRepository.Update(mappedPrestamosxpersona);
                var mappedResponse = _mapper.Map<PrestamosxpersonaResponse>(result);
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
