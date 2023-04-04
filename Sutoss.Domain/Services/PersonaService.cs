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
    public class PersonasService : BaseService, IPersonasService
    {
        private readonly IPersonaRepository _PersonaRepository;
        private readonly DomainSettings _appSettings;
        private readonly IMapper _mapper;
        public PersonasService(
            IPersonaRepository PersonaRepository,
            IMapper mapper,
            IOptions<DomainSettings> appSettings) : base()
        {
            _PersonaRepository = PersonaRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }

        // public async Task<PersonaResponse> Authenticate(PersonaResponse request)
        // {
        //     // var user = (await userRepository.All()).Where(x => request.UserName == x.UserName).FirstOrDefault();
        //     // if (user == null)
        //     // {
        //     //     throw new NotFoundException("User not found");
        //     // }
        //     // var result = new PasswordHasher<User>().VerifyHashedPassword(user, user.Hash, request.Password);
        //     // if (result == PasswordVerificationResult.Success)
        //     // {
        //     //     return new AuthResponse
        //     //     {
        //     //         UserId = user.UserId,
        //     //         Username = user.UserName,
        //     //         Token = generateJwtToken(user),
        //     //     };
        //     // }
        //     throw new UnauthorizedException();
        // }

        // private string generateJwtToken(User user)
        // {
        //     // generate token that is valid for 7 days
        //     var tokenHandler = new JwtSecurityTokenHandler();
        //     var key = Encoding.ASCII.GetBytes(appSettings.AppSettings.Secret);
        //     var tokenDescriptor = new SecurityTokenDescriptor
        //     {
        //         Subject = new ClaimsIdentity(new[] { new Claim("userId", user.UserId.ToString()) }),
        //         Expires = DateTime.UtcNow.AddDays(7),
        //         SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //     };
        //     var token = tokenHandler.CreateToken(tokenDescriptor);
        //     return tokenHandler.WriteToken(token);
        // }


        public async Task<PersonaResponse> Create(PersonaRequest newPersona )
        {
            var transaction = _PersonaRepository.BeginTransaction();
            try
            {
                Persona consulta = new Persona();   
                //preguntar si la persona existe
                consulta = (await _PersonaRepository.All()).FirstOrDefault(x=>x.PerNafiliadio==newPersona.PerNafiliadio);
                if(consulta ==null){
                   //insertas
                    Persona entity= _mapper.Map<Persona>(newPersona);
                    var addedPersona = await _PersonaRepository.Insert(entity);
                    transaction.Commit();
                    return _mapper.Map<PersonaResponse>(addedPersona);
                }
                else{
                    throw new Exception(message: "El legajo ya existe");
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {
            var transaction = _PersonaRepository.BeginTransaction();
            try
            {
                var result = (await _PersonaRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Persona not found");
                }
                await _PersonaRepository.Delete(result.IdPersona);
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public async Task<List<PersonaResponse>> GetAll(int? s, int? l, string q)
        {
            try
            {
                s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                l = l ?? 20;
                IQueryable<Persona> items = await _PersonaRepository.All();
                items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<List<PersonaResponse>>(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<PersonaResponse> GetAllPer(int? s, int? leg, string q)
        {
            try
            {
                Persona consulta = new Persona();
                consulta = (await _PersonaRepository.All()).FirstOrDefault(x=>x.PerNafiliadio==leg);

                // s = s != null && s.Value != 0 ? s.Value - 1 : 0;
                // // l = l ?? 10;
                // IQueryable<Persona> items = await _PersonaRepository.All();
                // items = ApplyFilterAndPagination(items, s.Value, q, l.Value);
                return _mapper.Map<PersonaResponse>(consulta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        


    public async Task<PersonaResponse> GetById(int id)
        {
            try
            {
                var result = (await _PersonaRepository.Get(id)).FirstOrDefault();
                if (result == null)
                {
                    throw new NotFoundException(message: "Persona not found");
                }
                return _mapper.Map<PersonaResponse>(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // public async Task<PersonaResponse> GetById(int id)
        // {
        //     try
        //     {
        //         var result = (await _PersonaRepository.Get(id)).FirstOrDefault(x=>x.PerNafiliadio==legajo);
        //         if (result == null)
        //         {
        //             throw new NotFoundException(message: "Persona not found");
        //         }
        //         return _mapper.Map<PersonaResponse>(result);
        //     }
        //     catch (Exception ex)
        //     {
        //         throw ex;
        //     }
        // }

        public async Task<PersonaResponse> Update(PersonaRequest updatedPersona )
        {
            var transaction = _PersonaRepository.BeginTransaction();
            try
            {
                var mappedPersona = (await _PersonaRepository.Get(updatedPersona.IdPersona)).FirstOrDefault();
		        
                mappedPersona.PerDni = updatedPersona.PerDni;
                mappedPersona.PerNombre = updatedPersona.PerNombre;
                mappedPersona.PerDomicilio = updatedPersona.PerDomicilio;
                mappedPersona.Pertelefono = updatedPersona.Pertelefono;
                mappedPersona.PerEstadocivil = updatedPersona.PerEstadocivil;
                //mappedPersona.PerNafiliadio = updatedPersona.PerNafiliadio;
                //mappedPersona.PerTipo = updatedPersona.PerTipo;
                mappedPersona.PerPuesto = updatedPersona.PerPuesto;
                mappedPersona.PerAntiguedad = updatedPersona.PerAntiguedad;
                mappedPersona.PerEdad = updatedPersona.PerEdad;

                var result = await _PersonaRepository.Update(mappedPersona);
                var mappedResponse = _mapper.Map<PersonaResponse>(result);
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
