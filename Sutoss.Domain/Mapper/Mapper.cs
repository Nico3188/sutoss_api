using AutoMapper;
using Sutoss.Domain.Services.Domain.Request;
using Sutoss.Domain.Services.Domain.Response;

namespace Sutoss.Domain.Services.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            ///// Request
            //CreateMap<BundleRequest, Bundle>();
            CreateMap<ProvinciumRequest,Provincium>();
            CreateMap<DepartamentoRequest,Departamento>();
            CreateMap<LocalidadRequest,Localidad>();
            CreateMap<InstalacionRequest,Instalacion>();
            CreateMap<AlquilerRequest, Alquiler>();
            CreateMap<ContratoRequest,Contrato>();
            CreateMap<CheckxcontratoRequest,Checkxcontrato>();
            CreateMap<CheklistRequest,Cheklist>();
            CreateMap<MultaxcontratoRequest,Multaxcontrato>();
            CreateMap<MultumRequest,Multum>();
            CreateMap<FpContratoRequest,FpContrato>();
            CreateMap<FormaPagoRequest, FormaPago>();
            CreateMap<PrestamoRequest, Prestamo>();
            CreateMap<PrestamosxpersonaRequest,Prestamosxpersona>();
            CreateMap<CuotaPrestamoRequest,CuotaPrestamo>();
            CreateMap<AnticipoRequest,Anticipo>();
            CreateMap<BeneficioRequest,Beneficio>();
            CreateMap<PersonaRequest,Persona>();
            CreateMap<DesignacionRequest,Designacion>();
            CreateMap<TurnoRequest,Turno>();
            CreateMap<EventoRequest,Evento>();
            CreateMap<CelebracionRequest,Celebracion>();
            CreateMap<GanadorRequest,Ganador>();
            CreateMap<PremioRequest,Premio>();
            CreateMap<SuscripcionRequest,Suscripcion>();
            CreateMap<BeneficioRequest,Beneficio>();
            CreateMap<GastoxinstRequest,Gastoxinst>();
            CreateMap<GastoRequest,Gasto>();
            CreateMap<ProductoRequest,Producto>();
            CreateMap<ProductoAsignadoRequest,ProductoAsignado>();
            CreateMap<MantenimientoRequest,Mantenimiento>();
            CreateMap<DetalleMantenimientoRequest,DetalleMantenimiento>();
            CreateMap<Servicio,ServicioRequest>();
            CreateMap<PedidoProductoRequest,PedidoProducto>();
            CreateMap<OrdenCompraRequest,OrdenCompra>();
            CreateMap<CompraRequest,Compra>();
            CreateMap<DetalleCompraRequest,DetalleCompra>();
            CreateMap<FacturaRequest, Factura>();
            CreateMap<DetalleFacturaRequest, DetalleFactura>();
            CreateMap<ProveedorRequest, Proveedor>();
            CreateMap<OrdenPagoRequest,OrdenPago>();
            
            ///// Responses
            //CreateMap<Bundle, BundleResponse>();
            CreateMap<Prestamo, PrestamoResponse>();
            CreateMap<Prestamosxpersona,PrestamosxpersonaResponse>();
            CreateMap<CuotaPrestamo,CuotaPrestamoResponse>();
            CreateMap<Anticipo,AnticipoResponse>();
            CreateMap<Beneficio,BeneficioResponse>();
            CreateMap<Provincium, ProvinciumResponse>();
            CreateMap<Departamento, DepartamentoRequest>();
            CreateMap<Localidad, LocalidadResponse>();
            CreateMap<Instalacion, InstalacionResponse>();
            CreateMap<Alquiler, AlquilerResponse>();
            CreateMap<Contrato, ContratoResponse>();
            CreateMap<Checkxcontrato,CheckxcontratoResponse>();
            CreateMap<Cheklist,CheklistResponse>();
            CreateMap<Multaxcontrato,MultaxcontratoResponse>();
            CreateMap<Multum, MultumResponse>(); 
            CreateMap<FpContrato,FpContratoResponse>();
            CreateMap<FormaPago, FormaPagoResponse>();
            CreateMap<Persona,PersonaResponse>();  
            CreateMap<Designacion,DesignacionResponse>();
            CreateMap<Turno,TurnoResponse>();
            CreateMap<Evento,EventoResponse>();
            CreateMap<Celebracion,CelebracionResponse>();
            CreateMap<Ganador,GanadorResponse>();
            CreateMap<Premio,PremioResponse>();
            CreateMap<Suscripcion,SuscripcionResponse>();
            CreateMap<Beneficio,BeneficioResponse>();
            CreateMap<Gastoxinst, GastoxinstResponse>();
            CreateMap<Gasto,GastoResponse>();
            CreateMap<Producto, ProductoResponse>();
            CreateMap<ProductoAsignado,ProductoAsignadoResponse>();
            CreateMap<Mantenimiento, MantenimientoResponse>();
            CreateMap<DetalleMantenimiento,DetalleMantenimientoRequest>();
            CreateMap<Servicio,ServicioResponse>();
            CreateMap<PedidoProducto,PedidoProductoResponse>();
            CreateMap<OrdenCompra,OrdenCompraResponse>();
            CreateMap<Compra, CompraResponse>();
            CreateMap<DetalleCompra,DetalleCompraResponse>();
            CreateMap<Factura, FacturaResponse>();
            CreateMap<DetalleFactura, DetalleFacturaResponse>();
            CreateMap<Proveedor, ProveedorResponse>();
            CreateMap<OrdenPago, OrdenCompraResponse>();
        }
    }
}
