using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Sutoss
{
    public partial class SutossContext : DbContext
    {
        public SutossContext()
        {
        }

        public SutossContext(DbContextOptions<SutossContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alquiler> Alquilers { get; set; }
        public virtual DbSet<Anticipo> Anticipos { get; set; }
        public virtual DbSet<Beneficio> Beneficios { get; set; }
        public virtual DbSet<Celebracion> Celebracions { get; set; }
        public virtual DbSet<Checkxcontrato> Checkxcontratos { get; set; }
        public virtual DbSet<Cheklist> Cheklists { get; set; }
        public virtual DbSet<Compra> Compras { get; set; }
        public virtual DbSet<Conocimiento> Conocimientos { get; set; }
        public virtual DbSet<Contrato> Contratos { get; set; }
        public virtual DbSet<Convenio> Convenios { get; set; }
        public virtual DbSet<Convenioxprov> Convenioxprovs { get; set; }
        public virtual DbSet<CuotaPp> CuotaPps { get; set; }
        public virtual DbSet<CuotaPrestamo> CuotaPrestamos { get; set; }
        public virtual DbSet<Cuotum> Cuota { get; set; }
        public virtual DbSet<Departamento> Departamentos { get; set; }
        public virtual DbSet<Designacion> Designacions { get; set; }
        public virtual DbSet<DetalleCompra> DetalleCompras { get; set; }
        public virtual DbSet<DetalleFactura> DetalleFacturas { get; set; }
        public virtual DbSet<DetalleMantenimiento> DetalleMantenimientos { get; set; }
        public virtual DbSet<Diciplina> Diciplinas { get; set; }
        public virtual DbSet<Dium> Dia { get; set; }
        public virtual DbSet<Enferemedad> Enferemedads { get; set; }
        public virtual DbSet<Evento> Eventos { get; set; }
        public virtual DbSet<ExpereiciaLaboral> ExpereiciaLaborals { get; set; }
        public virtual DbSet<Factura> Facturas { get; set; }
        public virtual DbSet<Familiar> Familiars { get; set; }
        public virtual DbSet<Familium> Familia { get; set; }
        public virtual DbSet<FormaPago> FormaPagos { get; set; }
        public virtual DbSet<FpContrato> FpContratos { get; set; }
        public virtual DbSet<Ganador> Ganadors { get; set; }
        public virtual DbSet<Gasto> Gastos { get; set; }
        public virtual DbSet<Gastoxinst> Gastoxinsts { get; set; }
        public virtual DbSet<Horario> Horarios { get; set; }
        public virtual DbSet<Idioma> Idiomas { get; set; }
        public virtual DbSet<Impuesto> Impuestos { get; set; }
        public virtual DbSet<Impxinstalacion> Impxinstalacions { get; set; }
        public virtual DbSet<Instalacion> Instalacions { get; set; }
        public virtual DbSet<Localidad> Localidads { get; set; }
        public virtual DbSet<LogOperacione> LogOperaciones { get; set; }
        public virtual DbSet<Mantenimiento> Mantenimientos { get; set; }
        public virtual DbSet<Multaxcontrato> Multaxcontratos { get; set; }
        public virtual DbSet<Multum> Multa { get; set; }
        public virtual DbSet<OrdenCompra> OrdenCompras { get; set; }
        public virtual DbSet<OrdenPago> OrdenPagos { get; set; }
        public virtual DbSet<PedidoProducto> PedidoProductos { get; set; }
        public virtual DbSet<Perfil> Perfils { get; set; }
        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<Postulante> Postulantes { get; set; }
        public virtual DbSet<Premio> Premios { get; set; }
        public virtual DbSet<Prestamo> Prestamos { get; set; }
        public virtual DbSet<Prestamosxpersona> Prestamosxpersonas { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<ProductoAsignado> ProductoAsignados { get; set; }
        public virtual DbSet<Proveedor> Proveedors { get; set; }
        public virtual DbSet<Provincium> Provincia { get; set; }
        public virtual DbSet<Servicio> Servicios { get; set; }
        public virtual DbSet<Suscripcion> Suscripcions { get; set; }
        public virtual DbSet<Turno> Turnos { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Vicnulo> Vicnulos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=3306;database=sutoss;uid=root;password=SoloyoNS311088", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Alquiler>(entity =>
            {
                entity.HasKey(e => e.IdAlquiler)
                    .HasName("PRIMARY");

                entity.ToTable("alquiler");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_spanish_ci");

                entity.HasIndex(e => e.InstalacionIdInstalacion, "fk_Alquiler_Instalacion1");

                entity.HasIndex(e => e.PersonaIdPersona, "fk_Alquiler_Persona1");

                entity.Property(e => e.IdAlquiler).HasColumnName("Id_Alquiler");

                entity.Property(e => e.ACantaduldos).HasColumnName("a.cantaduldos");

                entity.Property(e => e.ACantmenores).HasColumnName("a.cantmenores");

                entity.Property(e => e.AFfin)
                    .HasColumnType("datetime")
                    .HasColumnName("a.ffin");

                entity.Property(e => e.AFinicio)
                    .HasColumnType("datetime")
                    .HasColumnName("a.finicio");

                entity.Property(e => e.AMascotas).HasColumnName("a.mascotas");

                entity.Property(e => e.InstalacionIdInstalacion).HasColumnName("Instalacion_Id_Instalacion");

                entity.Property(e => e.PersonaIdPersona).HasColumnName("Persona_Id_Persona");

                entity.HasOne(d => d.InstalacionIdInstalacionNavigation)
                    .WithMany(p => p.Alquilers)
                    .HasForeignKey(d => d.InstalacionIdInstalacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Alquiler_Instalacion1");

                entity.HasOne(d => d.PersonaIdPersonaNavigation)
                    .WithMany(p => p.Alquilers)
                    .HasForeignKey(d => d.PersonaIdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Alquiler_Persona1");
            });

            modelBuilder.Entity<Anticipo>(entity =>
            {
                entity.HasKey(e => e.IdAnticipo)
                    .HasName("PRIMARY");

                entity.ToTable("anticipo");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_spanish_ci");

                entity.HasIndex(e => e.PersonaIdPersona, "fk_Anticipo_Persona_idx");

                entity.Property(e => e.IdAnticipo).HasColumnName("Id_Anticipo");

                entity.Property(e => e.AAprobado)
                    .IsRequired()
                    .HasMaxLength(4)
                    .HasColumnName("a. aprobado");

                entity.Property(e => e.AConcepto)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("a.concepto");

                entity.Property(e => e.AEstado)
                    .HasMaxLength(20)
                    .HasColumnName("a.estado");

                entity.Property(e => e.AFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("a.fecha");

                entity.Property(e => e.AMonto)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("a.monto");

                entity.Property(e => e.PersonaIdPersona).HasColumnName("Persona_Id_Persona");

                entity.HasOne(d => d.PersonaIdPersonaNavigation)
                    .WithMany(p => p.Anticipos)
                    .HasForeignKey(d => d.PersonaIdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Anticipo_Persona");
            });

            modelBuilder.Entity<Beneficio>(entity =>
            {
                entity.HasKey(e => e.IdBeneficio)
                    .HasName("PRIMARY");

                entity.ToTable("beneficio");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_spanish_ci");

                entity.Property(e => e.IdBeneficio).HasColumnName("Id_Beneficio");

                entity.Property(e => e.BDescripcion)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("b.descripcion");

                entity.Property(e => e.BNombre)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("b.nombre");
            });

            modelBuilder.Entity<Celebracion>(entity =>
            {
                entity.HasKey(e => e.IdCelebracion)
                    .HasName("PRIMARY");

                entity.ToTable("celebracion");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_spanish_ci");

                entity.HasIndex(e => e.EventoIdEvento, "fk_Celebracion_Evento1");

                entity.HasIndex(e => e.PersonaIdPersona, "fk_Celebracion_Persona1");

                entity.Property(e => e.IdCelebracion).HasColumnName("Id_Celebracion");

                entity.Property(e => e.CAsistencio)
                    .HasMaxLength(2)
                    .HasColumnName("c.asistencio");

                entity.Property(e => e.CConfirmado)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnName("c.confirmado");

                entity.Property(e => e.EventoIdEvento).HasColumnName("Evento_Id_Evento");

                entity.Property(e => e.PersonaIdPersona).HasColumnName("Persona_Id_Persona");

                entity.HasOne(d => d.EventoIdEventoNavigation)
                    .WithMany(p => p.Celebracions)
                    .HasForeignKey(d => d.EventoIdEvento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Celebracion_Evento1");

                entity.HasOne(d => d.PersonaIdPersonaNavigation)
                    .WithMany(p => p.Celebracions)
                    .HasForeignKey(d => d.PersonaIdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Celebracion_Persona1");
            });

            modelBuilder.Entity<Checkxcontrato>(entity =>
            {
                entity.HasKey(e => e.IdCheckxContrato)
                    .HasName("PRIMARY");

                entity.ToTable("checkxcontrato");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_spanish_ci");

                entity.HasIndex(e => e.CheklistIdChecklist, "fk_CheckxContrato_Cheklist1");

                entity.HasIndex(e => e.ContratoIdContrato, "fk_CheckxContrato_Contrato1");

                entity.Property(e => e.IdCheckxContrato).HasColumnName("Id_CheckxContrato");

                entity.Property(e => e.ChcFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("chc.fecha");

                entity.Property(e => e.ChcNumero)
                    .HasMaxLength(4)
                    .HasColumnName("chc.numero");

                entity.Property(e => e.ChcObservaciones)
                    .HasMaxLength(80)
                    .HasColumnName("chc.observaciones");

                entity.Property(e => e.ChcResponsables)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("chc.responsables");

                entity.Property(e => e.CheklistIdChecklist).HasColumnName("Cheklist_Id_Checklist");

                entity.Property(e => e.ContratoIdContrato).HasColumnName("Contrato_Id_Contrato");

                entity.HasOne(d => d.CheklistIdChecklistNavigation)
                    .WithMany(p => p.Checkxcontratos)
                    .HasForeignKey(d => d.CheklistIdChecklist)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CheckxContrato_Cheklist1");

                entity.HasOne(d => d.ContratoIdContratoNavigation)
                    .WithMany(p => p.Checkxcontratos)
                    .HasForeignKey(d => d.ContratoIdContrato)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CheckxContrato_Contrato1");
            });

            modelBuilder.Entity<Cheklist>(entity =>
            {
                entity.HasKey(e => e.IdChecklist)
                    .HasName("PRIMARY");

                entity.ToTable("cheklist");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_spanish_ci");

                entity.Property(e => e.IdChecklist).HasColumnName("Id_Checklist");

                entity.Property(e => e.ChCodigo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("ch.codigo");

                entity.Property(e => e.ChDescripcion)
                    .HasMaxLength(80)
                    .HasColumnName("ch.descripcion");

                entity.Property(e => e.ChDocumento)
                    .IsRequired()
                    .HasColumnName("ch.documento");

                entity.Property(e => e.ChNombre)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("ch.nombre");
            });

            modelBuilder.Entity<Compra>(entity =>
            {
                entity.HasKey(e => e.IdCompra)
                    .HasName("PRIMARY");

                entity.ToTable("compra");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_spanish_ci");

                entity.HasIndex(e => e.OrdenCompraIdOrdenCompra, "fk_Compra_Orden_Compra1");

                entity.Property(e => e.IdCompra).HasColumnName("Id_Compra");

                entity.Property(e => e.CompCodigo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("comp.codigo");

                entity.Property(e => e.CompEstado)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("comp.estado");

                entity.Property(e => e.CompFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("comp.fecha");

                entity.Property(e => e.CompNumero).HasColumnName("comp.numero");

                entity.Property(e => e.CompPreciofinal)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("comp.preciofinal");

                entity.Property(e => e.OrdenCompraIdOrdenCompra).HasColumnName("Orden_Compra_Id_Orden_Compra");

                entity.HasOne(d => d.OrdenCompraIdOrdenCompraNavigation)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.OrdenCompraIdOrdenCompra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Compra_Orden_Compra1");
            });

            modelBuilder.Entity<Conocimiento>(entity =>
            {
                entity.HasKey(e => e.IdConocimiento)
                    .HasName("PRIMARY");

                entity.ToTable("conocimientos");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_spanish_ci");

                entity.HasIndex(e => e.PostulanteIdPostulante, "fk_Conocimiento_Postulante_idx");

                entity.Property(e => e.IdConocimiento)
                    .ValueGeneratedNever()
                    .HasColumnName("idConocimiento");

                entity.Property(e => e.Conconocimiento)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("conconocimiento");

                entity.Property(e => e.Condescripcion)
                    .HasMaxLength(100)
                    .HasColumnName("condescripcion");

                entity.Property(e => e.Connivel)
                    .HasMaxLength(20)
                    .HasColumnName("connivel")
                    .HasComment("junior / intermedio / avanzado");

                entity.Property(e => e.PostulanteIdPostulante).HasColumnName("Postulante_id_Postulante");

                entity.HasOne(d => d.PostulanteIdPostulanteNavigation)
                    .WithMany(p => p.Conocimientos)
                    .HasForeignKey(d => d.PostulanteIdPostulante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Conocimiento_Postulante");
            });

            modelBuilder.Entity<Contrato>(entity =>
            {
                entity.HasKey(e => e.IdContrato)
                    .HasName("PRIMARY");

                entity.ToTable("contrato");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_spanish_ci");

                entity.HasIndex(e => e.AlquilerIdAlquiler, "fk_Contrato_Alquiler1");

                entity.HasIndex(e => e.PersonaIdPersona, "fk_Contrato_Persona1");

                entity.Property(e => e.IdContrato).HasColumnName("Id_Contrato");

                entity.Property(e => e.AlquilerIdAlquiler).HasColumnName("Alquiler_Id_Alquiler");

                entity.Property(e => e.CDescripcion)
                    .HasMaxLength(45)
                    .HasColumnName("c.descripcion");

                entity.Property(e => e.CNombre)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("c.nombre");

                entity.Property(e => e.CTexto)
                    .IsRequired()
                    .HasColumnName("c.texto");

                entity.Property(e => e.PersonaIdPersona).HasColumnName("Persona_Id_Persona");

                entity.HasOne(d => d.AlquilerIdAlquilerNavigation)
                    .WithMany(p => p.Contratos)
                    .HasForeignKey(d => d.AlquilerIdAlquiler)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Contrato_Alquiler1");

                entity.HasOne(d => d.PersonaIdPersonaNavigation)
                    .WithMany(p => p.Contratos)
                    .HasForeignKey(d => d.PersonaIdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Contrato_Persona1");
            });

            modelBuilder.Entity<Convenio>(entity =>
            {
                entity.HasKey(e => e.IdConvenio)
                    .HasName("PRIMARY");

                entity.ToTable("convenio");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_spanish_ci");

                entity.Property(e => e.IdConvenio).HasColumnName("Id_Convenio");

                entity.Property(e => e.ConDescripcion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("con.descripcion");

                entity.Property(e => e.ConDoc)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("con.doc");

                entity.Property(e => e.ConNombre)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("con.nombre");
            });

            modelBuilder.Entity<Convenioxprov>(entity =>
            {
                entity.HasKey(e => e.IdConvenioxProv)
                    .HasName("PRIMARY");

                entity.ToTable("convenioxprov");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_spanish_ci");

                entity.Property(e => e.IdConvenioxProv).HasColumnName("Id_ConvenioxProv");

                entity.Property(e => e.ConxpEstado)
                    .HasMaxLength(10)
                    .HasColumnName("conxp.estado");

                entity.Property(e => e.ConxpFfin)
                    .HasColumnType("datetime")
                    .HasColumnName("conxp.ffin");

                entity.Property(e => e.ConxpFinicio)
                    .HasColumnType("datetime")
                    .HasColumnName("conxp.finicio");

                entity.Property(e => e.IdConvenio).HasColumnName("Id_Convenio");

                entity.Property(e => e.IdPersona).HasColumnName("Id_Persona");
            });

            modelBuilder.Entity<CuotaPp>(entity =>
            {
                entity.HasKey(e => e.IdCuotaPp)
                    .HasName("PRIMARY");

                entity.ToTable("cuota_pp");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_spanish_ci");

                entity.Property(e => e.IdCuotaPp).HasColumnName("Id_Cuota_PP");

                entity.Property(e => e.CppCuota)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("cpp.cuota");

                entity.Property(e => e.CppEstado)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("cpp.estado");

                entity.Property(e => e.CppFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("cpp.fecha");
            });

            modelBuilder.Entity<CuotaPrestamo>(entity =>
            {
                entity.HasKey(e => e.IdCuotaPrestamo)
                    .HasName("PRIMARY");

                entity.ToTable("cuota_prestamo");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_spanish_ci");

                entity.Property(e => e.IdCuotaPrestamo).HasColumnName("idCuota_prestamo");

                entity.Property(e => e.CpCantcuotas).HasColumnName("cp.cantcuotas");

                entity.Property(e => e.CpEstado)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("cp.Estado");

                entity.Property(e => e.CpFpago)
                    .HasColumnType("datetime")
                    .HasColumnName("cp.fpago");

                entity.Property(e => e.CpImporte).HasColumnName("cp.importe");

                entity.Property(e => e.CpNumcuota).HasColumnName("cp.numcuota");

                entity.Property(e => e.IdPrestamosxpersona).HasColumnName("Id_Prestamosxpersona");
            });

            modelBuilder.Entity<Cuotum>(entity =>
            {
                entity.HasKey(e => e.IdCouta)
                    .HasName("PRIMARY");

                entity.ToTable("cuota");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_spanish_ci");

                entity.Property(e => e.IdCouta).HasColumnName("Id_couta");

                entity.Property(e => e.CoutaNombre)
                    .HasMaxLength(45)
                    .HasColumnName("couta.nombre");

                entity.Property(e => e.CoutaVigencia)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("couta.vigencia");
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.HasKey(e => e.IdDepartamento)
                    .HasName("PRIMARY");

                entity.ToTable("departamento");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_spanish_ci");

                entity.HasIndex(e => e.ProvinciaIdProvincia, "fk_Departamento_Provincia1");

                entity.Property(e => e.IdDepartamento).HasColumnName("Id_Departamento");

                entity.Property(e => e.DNombre)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("d.Nombre");

                entity.Property(e => e.ProvinciaIdProvincia).HasColumnName("Provincia_Id_Provincia");

                entity.HasOne(d => d.ProvinciaIdProvinciaNavigation)
                    .WithMany(p => p.Departamentos)
                    .HasForeignKey(d => d.ProvinciaIdProvincia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Departamento_Provincia1");
            });

            modelBuilder.Entity<Designacion>(entity =>
            {
                entity.HasKey(e => e.IdDesignacion)
                    .HasName("PRIMARY");

                entity.ToTable("designacion");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_spanish_ci");

                entity.HasIndex(e => e.InstalacionIdInstalacion, "fk_Designacion_Instalacion1");

                entity.HasIndex(e => e.PersonaIdPersona, "fk_Designacion_Persona1");

                entity.HasIndex(e => e.TurnoIdTurno, "fk_Designacion_Turno1");

                entity.Property(e => e.IdDesignacion).HasColumnName("Id_Designacion");

                entity.Property(e => e.DFin)
                    .HasColumnType("datetime")
                    .HasColumnName("d.fin");

                entity.Property(e => e.DInicio)
                    .HasColumnType("datetime")
                    .HasColumnName("d.inicio");

                entity.Property(e => e.DNombre)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("d.Nombre");

                entity.Property(e => e.InstalacionIdInstalacion).HasColumnName("Instalacion_Id_Instalacion");

                entity.Property(e => e.PersonaIdPersona).HasColumnName("Persona_Id_Persona");

                entity.Property(e => e.TurnoIdTurno).HasColumnName("Turno_Id_Turno");

                entity.HasOne(d => d.InstalacionIdInstalacionNavigation)
                    .WithMany(p => p.Designacions)
                    .HasForeignKey(d => d.InstalacionIdInstalacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Designacion_Instalacion1");

                entity.HasOne(d => d.PersonaIdPersonaNavigation)
                    .WithMany(p => p.Designacions)
                    .HasForeignKey(d => d.PersonaIdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Designacion_Persona1");

                entity.HasOne(d => d.TurnoIdTurnoNavigation)
                    .WithMany(p => p.Designacions)
                    .HasForeignKey(d => d.TurnoIdTurno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Designacion_Turno1");
            });

            modelBuilder.Entity<DetalleCompra>(entity =>
            {
                entity.HasKey(e => e.IdDetalleCompra)
                    .HasName("PRIMARY");

                entity.ToTable("detalle_compra");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_spanish_ci");

                entity.HasIndex(e => e.CompraIdCompra, "fk_Detalle_Compra_Compra1");

                entity.HasIndex(e => e.ProductoIdProducto, "fk_Detalle_Compra_Producto1");

                entity.Property(e => e.IdDetalleCompra).HasColumnName("Id_Detalle_Compra");

                entity.Property(e => e.CompraIdCompra).HasColumnName("Compra_Id_Compra");

                entity.Property(e => e.DetCantidad).HasColumnName("det.cantidad");

                entity.Property(e => e.DetPrecionitario).HasColumnName("det.precionitario");

                entity.Property(e => e.DetalleCompracol)
                    .HasMaxLength(45)
                    .HasColumnName("Detalle_Compracol");

                entity.Property(e => e.ProductoIdProducto).HasColumnName("Producto_Id_Producto");

                entity.HasOne(d => d.CompraIdCompraNavigation)
                    .WithMany(p => p.DetalleCompras)
                    .HasForeignKey(d => d.CompraIdCompra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Detalle_Compra_Compra1");

                entity.HasOne(d => d.ProductoIdProductoNavigation)
                    .WithMany(p => p.DetalleCompras)
                    .HasForeignKey(d => d.ProductoIdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Detalle_Compra_Producto1");
            });

            modelBuilder.Entity<DetalleFactura>(entity =>
            {
                entity.HasKey(e => e.IddetalleFactura)
                    .HasName("PRIMARY");

                entity.ToTable("detalle_factura");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_spanish_ci");

                entity.HasIndex(e => e.FacturaIdFactura, "fk_detalle_Factura_Factura1");

                entity.Property(e => e.IddetalleFactura).HasColumnName("iddetalle_Factura");

                entity.Property(e => e.DetfacCantidad).HasColumnName("detfac.cantidad");

                entity.Property(e => e.FacturaIdFactura).HasColumnName("Factura_Id_Factura");

                entity.HasOne(d => d.FacturaIdFacturaNavigation)
                    .WithMany(p => p.DetalleFacturas)
                    .HasForeignKey(d => d.FacturaIdFactura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_detalle_Factura_Factura1");
            });

            modelBuilder.Entity<DetalleMantenimiento>(entity =>
            {
                entity.HasKey(e => e.IdDetalleMantenimiento)
                    .HasName("PRIMARY");

                entity.ToTable("detalle_mantenimiento");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_spanish_ci");

                entity.HasIndex(e => e.MantenimientoIdMantenimiento, "fk_Detalle_Mantenimiento_Mantenimiento1");

                entity.HasIndex(e => e.ProductoIdProducto, "fk_Detalle_Mantenimiento_Producto1");

                entity.HasIndex(e => e.ServicioIdServicio, "fk_Detalle_Mantenimiento_Servicio1");

                entity.Property(e => e.IdDetalleMantenimiento).HasColumnName("Id_Detalle_Mantenimiento");

                entity.Property(e => e.DetmanCantidad).HasColumnName("detman.cantidad");

                entity.Property(e => e.MantenimientoIdMantenimiento).HasColumnName("Mantenimiento_Id_Mantenimiento");

                entity.Property(e => e.ProductoIdProducto).HasColumnName("Producto_Id_Producto");

                entity.Property(e => e.ServicioIdServicio).HasColumnName("Servicio_Id_Servicio");

                entity.HasOne(d => d.MantenimientoIdMantenimientoNavigation)
                    .WithMany(p => p.DetalleMantenimientos)
                    .HasForeignKey(d => d.MantenimientoIdMantenimiento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Detalle_Mantenimiento_Mantenimiento1");

                entity.HasOne(d => d.ProductoIdProductoNavigation)
                    .WithMany(p => p.DetalleMantenimientos)
                    .HasForeignKey(d => d.ProductoIdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Detalle_Mantenimiento_Producto1");

                entity.HasOne(d => d.ServicioIdServicioNavigation)
                    .WithMany(p => p.DetalleMantenimientos)
                    .HasForeignKey(d => d.ServicioIdServicio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Detalle_Mantenimiento_Servicio1");
            });

            modelBuilder.Entity<Diciplina>(entity =>
            {
                entity.HasKey(e => e.IdDiciplina)
                    .HasName("PRIMARY");

                entity.ToTable("diciplina");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_spanish_ci");

                entity.Property(e => e.IdDiciplina).HasColumnName("Id_Diciplina");

                entity.Property(e => e.DDescripcion)
                    .HasColumnType("text")
                    .HasColumnName("d.descripcion");

                entity.Property(e => e.DNomre)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("d.nomre");

                entity.Property(e => e.DUrlVideo)
                    .HasMaxLength(80)
                    .HasColumnName("d.url_video");
            });

            modelBuilder.Entity<Dium>(entity =>
            {
                entity.HasKey(e => e.IdDia)
                    .HasName("PRIMARY");

                entity.ToTable("dia");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_spanish_ci");

                entity.Property(e => e.IdDia).HasColumnName("Id_Dia");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Enferemedad>(entity =>
            {
                entity.HasKey(e => e.IdEnferemedad)
                    .HasName("PRIMARY");

                entity.ToTable("enferemedad");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_spanish_ci");

                entity.Property(e => e.IdEnferemedad).HasColumnName("Id_Enferemedad");

                entity.Property(e => e.ENombre)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("e.nombre");
            });

            modelBuilder.Entity<Evento>(entity =>
            {
                entity.HasKey(e => e.IdEvento)
                    .HasName("PRIMARY");

                entity.ToTable("evento");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_spanish_ci");

                entity.Property(e => e.IdEvento).HasColumnName("Id_Evento");

                entity.Property(e => e.ECarton).HasColumnName("e.carton");

                entity.Property(e => e.ECodigo).HasColumnName("e.codigo");

                entity.Property(e => e.EFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("e.fecha");

                entity.Property(e => e.ENombre)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("e.nombre");

                entity.Property(e => e.EPrecio)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("e.precio");

                entity.Property(e => e.EUbicacion)
                    .HasMaxLength(45)
                    .HasColumnName("e.ubicacion");
            });

            modelBuilder.Entity<ExpereiciaLaboral>(entity =>
            {
                entity.HasKey(e => e.IdExpereiciaLaboral)
                    .HasName("PRIMARY");

                entity.ToTable("expereicia_laboral");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_spanish_ci");

                entity.HasIndex(e => e.PostulanteIdPostulante, "fk_Experiencia_Laboral_Postulanta_idx");

                entity.Property(e => e.IdExpereiciaLaboral).HasColumnName("idExpereicia_Laboral");

                entity.Property(e => e.Expegreso)
                    .HasMaxLength(30)
                    .HasColumnName("expegreso");

                entity.Property(e => e.Expempresa)
                    .IsRequired()
                    .HasMaxLength(90)
                    .HasColumnName("expempresa");

                entity.Property(e => e.Expfingreso)
                    .HasMaxLength(30)
                    .HasColumnName("expfingreso");

                entity.Property(e => e.Expmotivobaja)
                    .HasMaxLength(90)
                    .HasColumnName("expmotivobaja");

                entity.Property(e => e.Exppuesto)
                    .IsRequired()
                    .HasMaxLength(90)
                    .HasColumnName("exppuesto");

                entity.Property(e => e.Exptareas)
                    .HasColumnType("text")
                    .HasColumnName("exptareas");

                entity.Property(e => e.PostulanteIdPostulante).HasColumnName("Postulante_id_Postulante");

                entity.HasOne(d => d.PostulanteIdPostulanteNavigation)
                    .WithMany(p => p.ExpereiciaLaborals)
                    .HasForeignKey(d => d.PostulanteIdPostulante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Experiencia_Laboral_Postulanta");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.IdFactura)
                    .HasName("PRIMARY");

                entity.ToTable("factura");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_spanish_ci");

                entity.HasIndex(e => e.CompraIdCompra, "fk_Factura_Compra1");

                entity.HasIndex(e => e.ImpuestoIdImpuseto, "fk_Factura_Impuesto1");

                entity.Property(e => e.IdFactura).HasColumnName("Id_Factura");

                entity.Property(e => e.CompraIdCompra).HasColumnName("Compra_Id_Compra");

                entity.Property(e => e.FCodigo)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("f.codigo");

                entity.Property(e => e.FMoneda)
                    .IsRequired()
                    .HasMaxLength(3)
                    .HasColumnName("f.moneda");

                entity.Property(e => e.FMonto).HasColumnName("f.monto");

                entity.Property(e => e.ImpuestoIdImpuseto).HasColumnName("Impuesto_Id_Impuseto");

                entity.HasOne(d => d.CompraIdCompraNavigation)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.CompraIdCompra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Factura_Compra1");

                entity.HasOne(d => d.ImpuestoIdImpusetoNavigation)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.ImpuestoIdImpuseto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Factura_Impuesto1");
            });

            modelBuilder.Entity<Familiar>(entity =>
            {
                entity.HasKey(e => e.IdFamiliar)
                    .HasName("PRIMARY");

                entity.ToTable("familiar");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_spanish_ci");

                entity.HasIndex(e => e.PersonaIdPersona, "fk_Familia_Persona_idx");

                entity.Property(e => e.IdFamiliar).HasColumnName("idFamiliar");

                entity.Property(e => e.FamDni)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("famDNI");

                entity.Property(e => e.FamDomicilio)
                    .HasMaxLength(45)
                    .HasColumnName("famDomicilio");

                entity.Property(e => e.FamNombre)
                    .IsRequired()
                    .HasMaxLength(85)
                    .HasColumnName("famNombre");

                entity.Property(e => e.FamVinculo)
                    .HasMaxLength(45)
                    .HasColumnName("famVinculo");

                entity.Property(e => e.Famnacimiento)
                    .HasColumnType("datetime")
                    .HasColumnName("famnacimiento");

                entity.Property(e => e.PersonaIdPersona).HasColumnName("Persona_Id_Persona");

                entity.HasOne(d => d.PersonaIdPersonaNavigation)
                    .WithMany(p => p.Familiars)
                    .HasForeignKey(d => d.PersonaIdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Familia_Persona");
            });

            modelBuilder.Entity<Familium>(entity =>
            {
                entity.HasKey(e => e.IdFamilia)
                    .HasName("PRIMARY");

                entity.ToTable("familia");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_spanish_ci");

                entity.Property(e => e.IdFamilia).HasColumnName("Id_Familia");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<FormaPago>(entity =>
            {
                entity.HasKey(e => e.IdFormaPago)
                    .HasName("PRIMARY");

                entity.ToTable("forma_pago");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_spanish_ci");

                entity.Property(e => e.IdFormaPago).HasColumnName("Id_Forma_Pago");

                entity.Property(e => e.FpNombre)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("fp.nombre");

                entity.Property(e => e.FpSigno)
                    .HasMaxLength(3)
                    .HasColumnName("fp.signo");
            });

            modelBuilder.Entity<FpContrato>(entity =>
            {
                entity.HasKey(e => e.IdFpContrato)
                    .HasName("PRIMARY");

                entity.ToTable("fp-contrato");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_spanish_ci");

                entity.HasIndex(e => e.ContratoIdContrato, "fk_FP-Contrato_Contrato1");

                entity.HasIndex(e => e.FormaPagoIdFormaPago, "fk_FP-Contrato_Forma_Pago1");

                entity.Property(e => e.IdFpContrato).HasColumnName("idFP-Contrato");

                entity.Property(e => e.ContratoIdContrato).HasColumnName("Contrato_Id_Contrato");

                entity.Property(e => e.FormaPagoIdFormaPago).HasColumnName("Forma_Pago_Id_Forma_Pago");

                entity.Property(e => e.FpcFcancelacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fpc.fcancelacion");

                entity.Property(e => e.FpcFpagosena)
                    .HasColumnType("datetime")
                    .HasColumnName("fpc.fpagosena");

                entity.Property(e => e.FpcMonto).HasColumnName("fpc.monto");

                entity.Property(e => e.FpcSena).HasColumnName("fpc.sena");

                entity.Property(e => e.FpcSenatipo)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("fpc.senatipo");

                entity.Property(e => e.FpcTipo)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("fpc.tipo");

                entity.Property(e => e.FpcUrlimg)
                    .HasMaxLength(100)
                    .HasColumnName("fpc.urlimg");

                entity.HasOne(d => d.ContratoIdContratoNavigation)
                    .WithMany(p => p.FpContratos)
                    .HasForeignKey(d => d.ContratoIdContrato)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_FP-Contrato_Contrato1");

                entity.HasOne(d => d.FormaPagoIdFormaPagoNavigation)
                    .WithMany(p => p.FpContratos)
                    .HasForeignKey(d => d.FormaPagoIdFormaPago)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_FP-Contrato_Forma_Pago1");
            });

            modelBuilder.Entity<Ganador>(entity =>
            {
                entity.HasKey(e => e.IdGanador)
                    .HasName("PRIMARY");

                entity.ToTable("ganador");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_spanish_ci");

                entity.HasIndex(e => e.CelebracionIdCelebracion, "fk_Ganador_Celebracion1");

                entity.HasIndex(e => e.PremioIdPremios, "fk_Ganador_Premio1");

                entity.Property(e => e.IdGanador).HasColumnName("idGanador");

                entity.Property(e => e.CelebracionIdCelebracion).HasColumnName("Celebracion_Id_Celebracion");

                entity.Property(e => e.PremioIdPremios).HasColumnName("Premio_Id_Premios");

                entity.HasOne(d => d.CelebracionIdCelebracionNavigation)
                    .WithMany(p => p.Ganadors)
                    .HasForeignKey(d => d.CelebracionIdCelebracion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Ganador_Celebracion1");

                entity.HasOne(d => d.PremioIdPremiosNavigation)
                    .WithMany(p => p.Ganadors)
                    .HasForeignKey(d => d.PremioIdPremios)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Ganador_Premio1");
            });

            modelBuilder.Entity<Gasto>(entity =>
            {
                entity.HasKey(e => e.IdGasto)
                    .HasName("PRIMARY");

                entity.ToTable("gasto");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_spanish_ci");

                entity.Property(e => e.IdGasto).HasColumnName("Id_Gasto");

                entity.Property(e => e.GFreciencia)
                    .HasMaxLength(45)
                    .HasColumnName("g.freciencia");

                entity.Property(e => e.GNombre)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("g.nombre");

                entity.Property(e => e.GObservacion)
                    .HasMaxLength(50)
                    .HasColumnName("g.observacion");

                entity.Property(e => e.GTipo)
                    .HasMaxLength(20)
                    .HasColumnName("g.tipo");
            });

            modelBuilder.Entity<Gastoxinst>(entity =>
            {
                entity.HasKey(e => e.IdGastoxInst)
                    .HasName("PRIMARY");

                entity.ToTable("gastoxinst");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_spanish_ci");

                entity.HasIndex(e => e.GastoIdGasto, "fk_GastoxInst_Gasto1");

                entity.HasIndex(e => e.InstalacionIdInstalacion, "fk_GastoxInst_Instalacion1");

                entity.Property(e => e.IdGastoxInst).HasColumnName("Id_GastoxInst");

                entity.Property(e => e.GastoIdGasto).HasColumnName("Gasto_Id_Gasto");

                entity.Property(e => e.GasxintEstado)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("gasxint.estado");

                entity.Property(e => e.GasxintMonto)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("gasxint.monto");

                entity.Property(e => e.GasxintVencimiento)
                    .HasColumnType("datetime")
                    .HasColumnName("gasxint.vencimiento");

                entity.Property(e => e.InstalacionIdInstalacion).HasColumnName("Instalacion_Id_Instalacion");

                entity.HasOne(d => d.GastoIdGastoNavigation)
                    .WithMany(p => p.Gastoxinsts)
                    .HasForeignKey(d => d.GastoIdGasto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_GastoxInst_Gasto1");

                entity.HasOne(d => d.InstalacionIdInstalacionNavigation)
                    .WithMany(p => p.Gastoxinsts)
                    .HasForeignKey(d => d.InstalacionIdInstalacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_GastoxInst_Instalacion1");
            });

            modelBuilder.Entity<Horario>(entity =>
            {
                entity.HasKey(e => e.IdHorario)
                    .HasName("PRIMARY");

                entity.ToTable("horario");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_spanish_ci");

                entity.Property(e => e.IdHorario).HasColumnName("Id_Horario");

                entity.Property(e => e.HHoraFin)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("h.hora_fin");

                entity.Property(e => e.HHoraInicio)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("h.hora_inicio");

                entity.Property(e => e.HNombre)
                    .HasMaxLength(45)
                    .HasColumnName("h.nombre");
            });

            modelBuilder.Entity<Idioma>(entity =>
            {
                entity.HasKey(e => e.IdIdioma)
                    .HasName("PRIMARY");

                entity.ToTable("idioma");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_spanish_ci");

                entity.HasIndex(e => e.PostulanteIdPostulante, "fk_Idioma_Postulante_idx");

                entity.Property(e => e.IdIdioma).HasColumnName("idIdioma");

                entity.Property(e => e.Idiconversacion)
                    .HasMaxLength(10)
                    .HasColumnName("idiconversacion");

                entity.Property(e => e.Idiescritura)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("idiescritura");

                entity.Property(e => e.Idiidioma)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("idiidioma");

                entity.Property(e => e.Idiinstitucion)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("idiinstitucion");

                entity.Property(e => e.Idilectura)
                    .HasMaxLength(10)
                    .HasColumnName("idilectura");

                entity.Property(e => e.PostulanteIdPostulante).HasColumnName("Postulante_id_Postulante");

                entity.HasOne(d => d.PostulanteIdPostulanteNavigation)
                    .WithMany(p => p.Idiomas)
                    .HasForeignKey(d => d.PostulanteIdPostulante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Idioma_Postulante");
            });

            modelBuilder.Entity<Impuesto>(entity =>
            {
                entity.HasKey(e => e.IdImpuseto)
                    .HasName("PRIMARY");

                entity.ToTable("impuesto");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_spanish_ci");

                entity.Property(e => e.IdImpuseto).HasColumnName("Id_Impuseto");

                entity.Property(e => e.INombre)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("i.nombre");
            });

            modelBuilder.Entity<Impxinstalacion>(entity =>
            {
                entity.HasKey(e => e.IdIMpxinstalacion)
                    .HasName("PRIMARY");

                entity.ToTable("impxinstalacion");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_spanish_ci");

                entity.HasIndex(e => e.ImpuestoIdImpuseto, "fk_Impxinstalacion_Impuesto1");

                entity.HasIndex(e => e.InstalacionIdInstalacion, "fk_Impxinstalacion_Instalacion1");

                entity.Property(e => e.IdIMpxinstalacion).HasColumnName("IdI_mpxinstalacion");

                entity.Property(e => e.ImpuestoIdImpuseto).HasColumnName("Impuesto_Id_Impuseto");

                entity.Property(e => e.ImpxintEstado)
                    .HasMaxLength(20)
                    .HasColumnName("impxint.estado");

                entity.Property(e => e.ImpxintMonto)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("impxint.monto");

                entity.Property(e => e.ImpxintVto)
                    .HasColumnType("datetime")
                    .HasColumnName("impxint.vto");

                entity.Property(e => e.InstalacionIdInstalacion).HasColumnName("Instalacion_Id_Instalacion");

                entity.HasOne(d => d.ImpuestoIdImpusetoNavigation)
                    .WithMany(p => p.Impxinstalacions)
                    .HasForeignKey(d => d.ImpuestoIdImpuseto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Impxinstalacion_Impuesto1");

                entity.HasOne(d => d.InstalacionIdInstalacionNavigation)
                    .WithMany(p => p.Impxinstalacions)
                    .HasForeignKey(d => d.InstalacionIdInstalacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Impxinstalacion_Instalacion1");
            });

            modelBuilder.Entity<Instalacion>(entity =>
            {
                entity.HasKey(e => e.IdInstalacion)
                    .HasName("PRIMARY");

                entity.ToTable("instalacion");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_spanish_ci");

                entity.HasIndex(e => e.LocalidadIdLocalidad, "fk_Instalacion_Localidad1");

                entity.Property(e => e.IdInstalacion).HasColumnName("Id_Instalacion");

                entity.Property(e => e.IDescripcion)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("i.descripcion");

                entity.Property(e => e.IMetroscuadrados)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("i.metroscuadrados");

                entity.Property(e => e.INombre)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("i.nombre");

                entity.Property(e => e.LocalidadIdLocalidad).HasColumnName("Localidad_Id_Localidad");

                entity.HasOne(d => d.LocalidadIdLocalidadNavigation)
                    .WithMany(p => p.Instalacions)
                    .HasForeignKey(d => d.LocalidadIdLocalidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Instalacion_Localidad1");
            });

            modelBuilder.Entity<Localidad>(entity =>
            {
                entity.HasKey(e => e.IdLocalidad)
                    .HasName("PRIMARY");

                entity.ToTable("localidad");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_spanish_ci");

                entity.HasIndex(e => e.DepartamentoIdDepartamento, "fk_Localidad_Departamento1");

                entity.Property(e => e.IdLocalidad).HasColumnName("Id_Localidad");

                entity.Property(e => e.DepartamentoIdDepartamento).HasColumnName("Departamento_Id_Departamento");

                entity.Property(e => e.LNombre)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("l.nombre");

                entity.HasOne(d => d.DepartamentoIdDepartamentoNavigation)
                    .WithMany(p => p.Localidads)
                    .HasForeignKey(d => d.DepartamentoIdDepartamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Localidad_Departamento1");
            });

            modelBuilder.Entity<LogOperacione>(entity =>
            {
                entity.HasKey(e => e.IdLogOperaciones)
                    .HasName("PRIMARY");

                entity.ToTable("log_operaciones");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_spanish_ci");

                entity.Property(e => e.IdLogOperaciones).HasColumnName("idLog_Operaciones");

                entity.Property(e => e.Operacion)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("usuario");
            });

            modelBuilder.Entity<Mantenimiento>(entity =>
            {
                entity.HasKey(e => e.IdMantenimiento)
                    .HasName("PRIMARY");

                entity.ToTable("mantenimiento");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_spanish_ci");

                entity.HasIndex(e => e.InstalacionIdInstalacion, "fk_Mantenimiento_Instalacion1");

                entity.Property(e => e.IdMantenimiento).HasColumnName("Id_Mantenimiento");

                entity.Property(e => e.InstalacionIdInstalacion).HasColumnName("Instalacion_Id_Instalacion");

                entity.Property(e => e.MAcargo)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("m.acargo");

                entity.Property(e => e.MCosto)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("m.costo");

                entity.Property(e => e.MEstado)
                    .HasMaxLength(10)
                    .HasColumnName("m.estado");

                entity.Property(e => e.MFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("m.fecha");

                entity.HasOne(d => d.InstalacionIdInstalacionNavigation)
                    .WithMany(p => p.Mantenimientos)
                    .HasForeignKey(d => d.InstalacionIdInstalacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Mantenimiento_Instalacion1");
            });

            modelBuilder.Entity<Multaxcontrato>(entity =>
            {
                entity.HasKey(e => e.IdMultaxContrato)
                    .HasName("PRIMARY");

                entity.ToTable("multaxcontrato");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_spanish_ci");

                entity.HasIndex(e => e.ContratoIdContrato, "fk_MultaxContrato_Contrato1");

                entity.HasIndex(e => e.MultaIdMulta, "fk_MultaxContrato_Multa1");

                entity.Property(e => e.IdMultaxContrato).HasColumnName("Id_MultaxContrato");

                entity.Property(e => e.ContratoIdContrato).HasColumnName("Contrato_Id_Contrato");

                entity.Property(e => e.MultaIdMulta).HasColumnName("Multa_Id_Multa");

                entity.Property(e => e.MxcEstado)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("mxc.estado");

                entity.Property(e => e.MxcFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("mxc.fecha");

                entity.Property(e => e.MxcObservacionl)
                    .HasColumnType("text")
                    .HasColumnName("mxc.observacionl");

                entity.HasOne(d => d.ContratoIdContratoNavigation)
                    .WithMany(p => p.Multaxcontratos)
                    .HasForeignKey(d => d.ContratoIdContrato)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_MultaxContrato_Contrato1");

                entity.HasOne(d => d.MultaIdMultaNavigation)
                    .WithMany(p => p.Multaxcontratos)
                    .HasForeignKey(d => d.MultaIdMulta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_MultaxContrato_Multa1");
            });

            modelBuilder.Entity<Multum>(entity =>
            {
                entity.HasKey(e => e.IdMulta)
                    .HasName("PRIMARY");

                entity.ToTable("multa");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_spanish_ci");

                entity.Property(e => e.IdMulta).HasColumnName("Id_Multa");

                entity.Property(e => e.MDescripcion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("m.descripcion");

                entity.Property(e => e.MMonto)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("m.monto");

                entity.Property(e => e.MNombre)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("m.nombre");
            });

            modelBuilder.Entity<OrdenCompra>(entity =>
            {
                entity.HasKey(e => e.IdOrdenCompra)
                    .HasName("PRIMARY");

                entity.ToTable("orden_compra");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_spanish_ci");

                entity.HasIndex(e => e.PedidoProductoIdPedidoProducto, "fk_Orden_Compra_Pedido_Producto1");

                entity.Property(e => e.IdOrdenCompra).HasColumnName("Id_Orden_Compra");

                entity.Property(e => e.OcCargadopor)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("oc.cargadopor");

                entity.Property(e => e.OcCodigo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("oc_codigo");

                entity.Property(e => e.OcEstado)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("oc_estado");

                entity.Property(e => e.OcFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("oc_fecha");

                entity.Property(e => e.OcNumero).HasColumnName("oc_numero");

                entity.Property(e => e.PedidoProductoIdPedidoProducto).HasColumnName("Pedido_Producto_Id_Pedido_Producto");

                entity.HasOne(d => d.PedidoProductoIdPedidoProductoNavigation)
                    .WithMany(p => p.OrdenCompras)
                    .HasForeignKey(d => d.PedidoProductoIdPedidoProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Orden_Compra_Pedido_Producto1");
            });

            modelBuilder.Entity<OrdenPago>(entity =>
            {
                entity.HasKey(e => e.IdRdenPago)
                    .HasName("PRIMARY");

                entity.ToTable("orden_pago");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_spanish_ci");

                entity.HasIndex(e => e.ProveedorIdProveedor, "fk_Orden_Pago_Proveedor1");

                entity.Property(e => e.IdRdenPago).HasColumnName("Id_rden_Pago");

                entity.Property(e => e.OpCodigo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("op_codigo");

                entity.Property(e => e.OpFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("op.fecha");

                entity.Property(e => e.OpMonto)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("op.monto");

                entity.Property(e => e.OpNumero).HasColumnName("op.numero");

                entity.Property(e => e.ProveedorIdProveedor).HasColumnName("Proveedor_Id_Proveedor");

                entity.HasOne(d => d.ProveedorIdProveedorNavigation)
                    .WithMany(p => p.OrdenPagos)
                    .HasForeignKey(d => d.ProveedorIdProveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Orden_Pago_Proveedor1");
            });

            modelBuilder.Entity<PedidoProducto>(entity =>
            {
                entity.HasKey(e => e.IdPedidoProducto)
                    .HasName("PRIMARY");

                entity.ToTable("pedido_producto");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_spanish_ci");

                entity.HasIndex(e => e.MantenimientoIdMantenimiento, "fk_Pedido_Producto_Mantenimiento1");

                entity.Property(e => e.IdPedidoProducto).HasColumnName("Id_Pedido_Producto");

                entity.Property(e => e.MantenimientoIdMantenimiento).HasColumnName("Mantenimiento_Id_Mantenimiento");

                entity.Property(e => e.PpAprueba)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("pp.aprueba");

                entity.Property(e => e.PpAutorizado)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnName("pp.autorizado")
                    .IsFixedLength();

                entity.Property(e => e.PpCodigo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("pp.codigo");

                entity.Property(e => e.PpNumero).HasColumnName("pp.numero");

                entity.Property(e => e.PpPedidopor)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("pp.pedidopor");

                entity.HasOne(d => d.MantenimientoIdMantenimientoNavigation)
                    .WithMany(p => p.PedidoProductos)
                    .HasForeignKey(d => d.MantenimientoIdMantenimiento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Pedido_Producto_Mantenimiento1");
            });

            modelBuilder.Entity<Perfil>(entity =>
            {
                entity.HasKey(e => e.IdPerfil)
                    .HasName("PRIMARY");

                entity.ToTable("perfil");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_spanish_ci");

                entity.Property(e => e.IdPerfil).HasColumnName("Id_Perfil");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("descripcion");

                entity.Property(e => e.PNombre)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("p.nombre");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.IdPersona)
                    .HasName("PRIMARY");

                entity.ToTable("persona");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_spanish_ci");

                entity.Property(e => e.IdPersona).HasColumnName("Id_Persona");

                entity.Property(e => e.PerAntiguedad).HasColumnName("per_antiguedad");

                entity.Property(e => e.PerDni).HasColumnName("per_dni");

                entity.Property(e => e.PerDomicilio)
                    .HasMaxLength(80)
                    .HasColumnName("per_domicilio");

                entity.Property(e => e.PerEdad).HasColumnName("per_edad");

                entity.Property(e => e.PerEstado)
                    .HasMaxLength(20)
                    .HasColumnName("per_estado")
                    .HasComment("Activo, jubilado, Fallecido");

                entity.Property(e => e.PerEstadocivil)
                    .HasMaxLength(45)
                    .HasColumnName("per_estadocivil");

                entity.Property(e => e.PerFechnac)
                    .HasColumnType("datetime")
                    .HasColumnName("per_fechnac");

                entity.Property(e => e.PerFingresol)
                    .HasColumnType("datetime")
                    .HasColumnName("per_fingresol");

                entity.Property(e => e.PerNafiliadio).HasColumnName("per_nafiliadio");

                entity.Property(e => e.PerNombre)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("per_nombre");

                entity.Property(e => e.PerPuesto)
                    .HasMaxLength(45)
                    .HasColumnName("per_puesto");

                entity.Property(e => e.PerTipo)
                    .HasMaxLength(45)
                    .HasColumnName("per_tipo")
                    .HasComment("Borrado, NoBorrado");

                entity.Property(e => e.Pertelefono)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("pertelefono");
            });

            modelBuilder.Entity<Postulante>(entity =>
            {
                entity.HasKey(e => e.IdPostulante)
                    .HasName("PRIMARY");

                entity.ToTable("postulante");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_spanish_ci");

                entity.HasIndex(e => e.PersonaIdPersona, "fk_Postulante_Persona_idx");

                entity.Property(e => e.IdPostulante).HasColumnName("idPostulante");

                entity.Property(e => e.PersonaIdPersona).HasColumnName("Persona_Id_Persona");

                entity.Property(e => e.PostApellido)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("postApellido");

                entity.Property(e => e.PostCategoriareg)
                    .HasMaxLength(6)
                    .HasColumnName("postCategoriareg");

                entity.Property(e => e.PostDni).HasColumnName("postDNI");

                entity.Property(e => e.PostEstcivil)
                    .HasMaxLength(25)
                    .HasColumnName("postEstcivil");

                entity.Property(e => e.PostFnac)
                    .HasColumnType("datetime")
                    .HasColumnName("postFnac");

                entity.Property(e => e.PostLugNac)
                    .HasMaxLength(80)
                    .HasColumnName("postLugNac");

                entity.Property(e => e.PostNacionalidad)
                    .HasMaxLength(25)
                    .HasColumnName("postNacionalidad");

                entity.Property(e => e.PostNivelalcanzado)
                    .HasMaxLength(44)
                    .HasColumnName("postNivelalcanzado")
                    .HasComment("finalizado / incompleto / cursando\n");

                entity.Property(e => e.PostNivelestu)
                    .HasMaxLength(45)
                    .HasColumnName("postNivelestu");

                entity.Property(e => e.PostNombre)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("postNombre");

                entity.Property(e => e.PostNombreinst)
                    .HasMaxLength(80)
                    .HasColumnName("postNombreinst");

                entity.Property(e => e.PostRegConducir)
                    .HasMaxLength(2)
                    .HasColumnName("postRegConducir")
                    .HasComment("SI/No");

                entity.Property(e => e.PostTituloobt)
                    .HasMaxLength(80)
                    .HasColumnName("postTituloobt");

                entity.Property(e => e.Postcorreo)
                    .HasMaxLength(45)
                    .HasColumnName("postcorreo");

                entity.Property(e => e.Postdomicilio)
                    .HasMaxLength(80)
                    .HasColumnName("postdomicilio");

                entity.Property(e => e.Postel).HasColumnName("postel");

                entity.Property(e => e.Postfsolicitud)
                    .HasColumnType("datetime")
                    .HasColumnName("postfsolicitud");

                entity.Property(e => e.Postnumsolicitud).HasColumnName("postnumsolicitud");

                entity.Property(e => e.Postvinculoafil)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("postvinculoafil");

                entity.HasOne(d => d.PersonaIdPersonaNavigation)
                    .WithMany(p => p.Postulantes)
                    .HasForeignKey(d => d.PersonaIdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Postulante_Persona");
            });

            modelBuilder.Entity<Premio>(entity =>
            {
                entity.HasKey(e => e.IdPremios)
                    .HasName("PRIMARY");

                entity.ToTable("premio");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_spanish_ci");

                entity.Property(e => e.IdPremios).HasColumnName("Id_Premios");

                entity.Property(e => e.PDescriopcion)
                    .HasColumnType("text")
                    .HasColumnName("p.descriopcion");

                entity.Property(e => e.PNombre)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("p.nombre");
            });

            modelBuilder.Entity<Prestamo>(entity =>
            {
                entity.HasKey(e => e.IdPrestamo)
                    .HasName("PRIMARY");

                entity.ToTable("prestamo");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_spanish_ci");

                entity.Property(e => e.IdPrestamo).HasColumnName("Id_Prestamo");

                entity.Property(e => e.PreEstado)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("pre.estado");

                entity.Property(e => e.PreInteres)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("pre.interes");

                entity.Property(e => e.PreMonto)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("pre.monto");

                entity.Property(e => e.PreNombre)
                    .HasMaxLength(45)
                    .HasColumnName("pre.nombre");
            });

            modelBuilder.Entity<Prestamosxpersona>(entity =>
            {
                entity.HasKey(e => e.IdPrestamosxpersona)
                    .HasName("PRIMARY");

                entity.ToTable("prestamosxpersona");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_spanish_ci");

                entity.HasIndex(e => e.PersonaIdPersona, "fk_Prestamosxpersona_Persona1");

                entity.HasIndex(e => e.PrestamoIdPrestamo, "fk_Prestamosxpersona_Prestamo1");

                entity.Property(e => e.IdPrestamosxpersona).HasColumnName("Id_Prestamosxpersona");

                entity.Property(e => e.PersonaIdPersona).HasColumnName("Persona_Id_Persona");

                entity.Property(e => e.PpCantCuotas).HasColumnName("pp.cant_cuotas");

                entity.Property(e => e.PpEstado)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("pp.estado");

                entity.Property(e => e.PpFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("pp.fecha");

                entity.Property(e => e.PpObrsevacion)
                    .HasColumnType("text")
                    .HasColumnName("pp.obrsevacion");

                entity.Property(e => e.PrestamoIdPrestamo).HasColumnName("Prestamo_Id_Prestamo");

                entity.HasOne(d => d.PersonaIdPersonaNavigation)
                    .WithMany(p => p.Prestamosxpersonas)
                    .HasForeignKey(d => d.PersonaIdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Prestamosxpersona_Persona1");

                entity.HasOne(d => d.PrestamoIdPrestamoNavigation)
                    .WithMany(p => p.Prestamosxpersonas)
                    .HasForeignKey(d => d.PrestamoIdPrestamo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Prestamosxpersona_Prestamo1");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PRIMARY");

                entity.ToTable("producto");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_spanish_ci");

                entity.Property(e => e.IdProducto).HasColumnName("Id_Producto");

                entity.Property(e => e.PCantidad).HasColumnName("p.cantidad");

                entity.Property(e => e.PCodBarra).HasColumnName("p.cod_barra");

                entity.Property(e => e.PCodigo).HasColumnName("p.codigo");

                entity.Property(e => e.PDescripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("p.descripcion");

                entity.Property(e => e.PEstado)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasColumnName("p.estado");

                entity.Property(e => e.PFCompra)
                    .HasColumnType("datetime")
                    .HasColumnName("p.f_compra");

                entity.Property(e => e.PNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("p.nombre");

                entity.Property(e => e.PUnidad)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("p.unidad");
            });

            modelBuilder.Entity<ProductoAsignado>(entity =>
            {
                entity.HasKey(e => e.IdProductoAsignado)
                    .HasName("PRIMARY");

                entity.ToTable("producto_asignado");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_spanish_ci");

                entity.HasIndex(e => e.InstalacionIdInstalacion, "fk_Producto_Asignado_Instalacion1");

                entity.HasIndex(e => e.ProductoIdProducto, "fk_Producto_Asignado_Producto1");

                entity.Property(e => e.IdProductoAsignado).HasColumnName("Id_Producto_Asignado");

                entity.Property(e => e.InstalacionIdInstalacion).HasColumnName("Instalacion_Id_Instalacion");

                entity.Property(e => e.PaEstadoProducto)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("pa.estado_producto");

                entity.Property(e => e.PaFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("pa.fecha");

                entity.Property(e => e.ProductoIdProducto).HasColumnName("Producto_Id_Producto");

                entity.HasOne(d => d.InstalacionIdInstalacionNavigation)
                    .WithMany(p => p.ProductoAsignados)
                    .HasForeignKey(d => d.InstalacionIdInstalacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Producto_Asignado_Instalacion1");

                entity.HasOne(d => d.ProductoIdProductoNavigation)
                    .WithMany(p => p.ProductoAsignados)
                    .HasForeignKey(d => d.ProductoIdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Producto_Asignado_Producto1");
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.HasKey(e => e.IdProveedor)
                    .HasName("PRIMARY");

                entity.ToTable("proveedor");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_spanish_ci");

                entity.Property(e => e.IdProveedor).HasColumnName("Id_Proveedor");

                entity.Property(e => e.Cuit).HasColumnName("cuit");

                entity.Property(e => e.PCelcontacto)
                    .HasMaxLength(45)
                    .HasColumnName("p.celcontacto");

                entity.Property(e => e.PCelular).HasColumnName("p.celular");

                entity.Property(e => e.PCondicionanteiva)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("p.condicionanteiva");

                entity.Property(e => e.PCorreo)
                    .HasMaxLength(80)
                    .HasColumnName("p.correo");

                entity.Property(e => e.PDomicilio)
                    .HasMaxLength(80)
                    .HasColumnName("p.domicilio");

                entity.Property(e => e.PNombre)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("p.nombre");

                entity.Property(e => e.PNombrecontacto)
                    .HasMaxLength(80)
                    .HasColumnName("p.nombrecontacto");

                entity.Property(e => e.PRazonsocial)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("p.razonsocial");
            });

            modelBuilder.Entity<Provincium>(entity =>
            {
                entity.HasKey(e => e.IdProvincia)
                    .HasName("PRIMARY");

                entity.ToTable("provincia");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_spanish_ci");

                entity.Property(e => e.IdProvincia).HasColumnName("Id_Provincia");

                entity.Property(e => e.PCodigo)
                    .HasMaxLength(5)
                    .HasColumnName("p.codigo");

                entity.Property(e => e.PNombre)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("p.nombre");
            });

            modelBuilder.Entity<Servicio>(entity =>
            {
                entity.HasKey(e => e.IdServicio)
                    .HasName("PRIMARY");

                entity.ToTable("servicio");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_spanish_ci");

                entity.Property(e => e.IdServicio).HasColumnName("Id_Servicio");

                entity.Property(e => e.SCosto)
                    .HasMaxLength(10)
                    .HasColumnName("s.costo");

                entity.Property(e => e.SHoras)
                    .HasMaxLength(10)
                    .HasColumnName("s.horas");

                entity.Property(e => e.SNombre)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("s.nombre");

                entity.Property(e => e.SPasos)
                    .HasColumnType("text")
                    .HasColumnName("s.pasos");

                entity.Property(e => e.SPersonalnecesario)
                    .HasMaxLength(80)
                    .HasColumnName("s.personalnecesario");
            });

            modelBuilder.Entity<Suscripcion>(entity =>
            {
                entity.HasKey(e => e.IdSuscripcion)
                    .HasName("PRIMARY");

                entity.ToTable("suscripcion");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_spanish_ci");

                entity.HasIndex(e => e.BeneficioIdBeneficio, "fk_Suscripcion_Beneficio1");

                entity.HasIndex(e => e.PersonaIdPersona, "fk_Suscripcion_Persona1");

                entity.Property(e => e.IdSuscripcion).HasColumnName("Id_Suscripcion");

                entity.Property(e => e.BeneficioIdBeneficio).HasColumnName("Beneficio_Id_Beneficio");

                entity.Property(e => e.PersonaIdPersona).HasColumnName("Persona_Id_Persona");

                entity.Property(e => e.SCantidad).HasColumnName("s.cantidad");

                entity.Property(e => e.SFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("s.fecha");

                entity.HasOne(d => d.BeneficioIdBeneficioNavigation)
                    .WithMany(p => p.Suscripcions)
                    .HasForeignKey(d => d.BeneficioIdBeneficio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Suscripcion_Beneficio1");

                entity.HasOne(d => d.PersonaIdPersonaNavigation)
                    .WithMany(p => p.Suscripcions)
                    .HasForeignKey(d => d.PersonaIdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Suscripcion_Persona1");
            });

            modelBuilder.Entity<Turno>(entity =>
            {
                entity.HasKey(e => e.IdTurno)
                    .HasName("PRIMARY");

                entity.ToTable("turno");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_spanish_ci");

                entity.Property(e => e.IdTurno).HasColumnName("Id_Turno");

                entity.Property(e => e.Observacion).HasMaxLength(80);

                entity.Property(e => e.THoraFin)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasColumnName("t.hora_fin");

                entity.Property(e => e.THoraInicio)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasColumnName("t.hora_inicio");

                entity.Property(e => e.TNombre)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("t.Nombre");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PRIMARY");

                entity.ToTable("user");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_spanish_ci");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.Hash)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("hash");

                entity.Property(e => e.Usermail)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("usermail");

                entity.Property(e => e.Usernombre)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("usernombre");

                entity.Property(e => e.Userrol)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("userrol");
            });

            modelBuilder.Entity<Vicnulo>(entity =>
            {
                entity.HasKey(e => e.IdVicnulo)
                    .HasName("PRIMARY");

                entity.ToTable("vicnulo");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_spanish_ci");

                entity.Property(e => e.IdVicnulo).HasColumnName("Id_Vicnulo");

                entity.Property(e => e.VNombre)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("v.nombre");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
