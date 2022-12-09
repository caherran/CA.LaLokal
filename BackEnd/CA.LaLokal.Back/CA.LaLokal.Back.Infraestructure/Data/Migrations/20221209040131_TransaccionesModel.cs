using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CA.LaLokal.Back.Infraestructure.Migrations
{
    public partial class TransaccionesModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mas_EstadoCliente");

            migrationBuilder.CreateTable(
                name: "mas_EstadoUsuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mas_EstadoUsuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoIdentificacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoIdentificacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    TipoUsuarioId = table.Column<int>(type: "int", nullable: false),
                    UsuarioEncargadoId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    EstadoUsuarioId = table.Column<int>(type: "int", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    ApellIdos = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    TipoPersonaId = table.Column<int>(type: "int", nullable: false),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    TelefonoFijo = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    TelefonoMovil = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoIdentificacionId = table.Column<int>(type: "int", nullable: false),
                    NumeroIdentificacion = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    MedioCaptacionId = table.Column<int>(type: "int", nullable: false),
                    ReferidoPor = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    DatosAdicionales = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CiudadId = table.Column<int>(type: "int", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CopiaCedula = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    ContratoPrestacion = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    RUT = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    URLFoto = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_mas_Ciudad_CiudadId",
                        column: x => x.CiudadId,
                        principalTable: "mas_Ciudad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuario_mas_EstadoUsuario_EstadoUsuarioId",
                        column: x => x.EstadoUsuarioId,
                        principalTable: "mas_EstadoUsuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuario_mas_MedioCaptacion_MedioCaptacionId",
                        column: x => x.MedioCaptacionId,
                        principalTable: "mas_MedioCaptacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuario_mas_TipoPersona_TipoPersonaId",
                        column: x => x.TipoPersonaId,
                        principalTable: "mas_TipoPersona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuario_mas_TipoUsuario_TipoUsuarioId",
                        column: x => x.TipoUsuarioId,
                        principalTable: "mas_TipoUsuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuario_TipoIdentificacion_TipoIdentificacionId",
                        column: x => x.TipoIdentificacionId,
                        principalTable: "TipoIdentificacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuario_Usuario_UsuarioEncargadoId",
                        column: x => x.UsuarioEncargadoId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inmueble",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    EstadoPublicacionId = table.Column<int>(type: "int", nullable: false),
                    GestorInmuebleId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    TipoInmuebleId = table.Column<int>(type: "int", nullable: false),
                    MatriculaInmobiliaria = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    EstadoFisicoPropiedadId = table.Column<int>(type: "int", nullable: false),
                    Ano = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    EstratoId = table.Column<int>(type: "int", nullable: false),
                    AlcobaId = table.Column<int>(type: "int", nullable: false),
                    BanoId = table.Column<int>(type: "int", nullable: false),
                    GarajeId = table.Column<int>(type: "int", nullable: false),
                    PisoId = table.Column<int>(type: "int", nullable: false),
                    AreaPrivada = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AreaConstruIda = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AreaTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorGasNatural = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorTelefoniaInternet = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorEnergia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorAgua = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CiudadId = table.Column<int>(type: "int", nullable: false),
                    ZonaBarrioId = table.Column<int>(type: "int", nullable: false),
                    CodigoPostal = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    NoPublicar = table.Column<bool>(type: "bit", nullable: false),
                    SoloZona = table.Column<bool>(type: "bit", nullable: false),
                    PuntoExacto = table.Column<bool>(type: "bit", nullable: false),
                    DireccionMapa = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inmueble", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inmueble_mas_Alcoba_AlcobaId",
                        column: x => x.AlcobaId,
                        principalTable: "mas_Alcoba",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inmueble_mas_Bano_BanoId",
                        column: x => x.BanoId,
                        principalTable: "mas_Bano",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inmueble_mas_Ciudad_CiudadId",
                        column: x => x.CiudadId,
                        principalTable: "mas_Ciudad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inmueble_mas_EstadoFisicoPropiedad_EstadoFisicoPropiedadId",
                        column: x => x.EstadoFisicoPropiedadId,
                        principalTable: "mas_EstadoFisicoPropiedad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inmueble_mas_EstadoPublicacion_EstadoPublicacionId",
                        column: x => x.EstadoPublicacionId,
                        principalTable: "mas_EstadoPublicacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inmueble_mas_Estrato_EstratoId",
                        column: x => x.EstratoId,
                        principalTable: "mas_Estrato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inmueble_mas_Garaje_GarajeId",
                        column: x => x.GarajeId,
                        principalTable: "mas_Garaje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inmueble_mas_Piso_PisoId",
                        column: x => x.PisoId,
                        principalTable: "mas_Piso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inmueble_mas_TipoInmueble_TipoInmuebleId",
                        column: x => x.TipoInmuebleId,
                        principalTable: "mas_TipoInmueble",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inmueble_mas_ZonaBarrio_ZonaBarrioId",
                        column: x => x.ZonaBarrioId,
                        principalTable: "mas_ZonaBarrio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inmueble_Usuario_GestorInmuebleId",
                        column: x => x.GestorInmuebleId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Proyecto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    UsuarioEncargadoId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    EstadoProyectoId = table.Column<int>(type: "int", nullable: false),
                    TipoInmuebleId = table.Column<int>(type: "int", nullable: false),
                    TipoNegocioId = table.Column<int>(type: "int", nullable: false),
                    TipoMonedaId = table.Column<int>(type: "int", nullable: false),
                    MontoTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CantIdadInversionistas = table.Column<int>(type: "int", nullable: false),
                    MontoMinimoInversion = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MontoMaximoInversion = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RentabilIdadTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RentabilIdadAnalizada = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PlazoRetornoEsperado = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    TotalAFinanciar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CostoProyecto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IngresoEstimadoVenta = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RentabilIdad = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreacionSpA = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InscripciónSpA = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EstudioTítulos = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PromesaEscrituraCompra = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InscripciónPropiedadCBR = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ContabilIdadRentaAnual = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ContabilIdadMensual = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Contribuciones = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PatenteComercialSpA = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CompraTerreno = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ComisiónCorretajeCompra = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProyectoParcelación = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MarketingVenta = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FondoReservaProyecto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PromesaEscrituraVenta = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CierreSpA = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyecto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proyecto_mas_EstadoProyecto_EstadoProyectoId",
                        column: x => x.EstadoProyectoId,
                        principalTable: "mas_EstadoProyecto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Proyecto_mas_TipoInmueble_TipoInmuebleId",
                        column: x => x.TipoInmuebleId,
                        principalTable: "mas_TipoInmueble",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Proyecto_mas_TipoMoneda_TipoMonedaId",
                        column: x => x.TipoMonedaId,
                        principalTable: "mas_TipoMoneda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Proyecto_mas_TipoNegocio_TipoNegocioId",
                        column: x => x.TipoNegocioId,
                        principalTable: "mas_TipoNegocio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Proyecto_Usuario_UsuarioEncargadoId",
                        column: x => x.UsuarioEncargadoId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioDemanda",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    TipoInmuebleId = table.Column<int>(type: "int", nullable: false),
                    TipoNegocioId = table.Column<int>(type: "int", nullable: false),
                    CiudadId = table.Column<int>(type: "int", nullable: false),
                    ZonaBarrioId = table.Column<int>(type: "int", nullable: false),
                    TipoMonedaId = table.Column<int>(type: "int", nullable: false),
                    PresupuestoMinimo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PresupuestoMaximo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AreaMinima = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AreaMaxima = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BanoId = table.Column<int>(type: "int", nullable: false),
                    GarajeId = table.Column<int>(type: "int", nullable: false),
                    DetallePropiedad = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioDemanda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioDemanda_mas_Bano_BanoId",
                        column: x => x.BanoId,
                        principalTable: "mas_Bano",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsuarioDemanda_mas_Ciudad_CiudadId",
                        column: x => x.CiudadId,
                        principalTable: "mas_Ciudad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsuarioDemanda_mas_Garaje_GarajeId",
                        column: x => x.GarajeId,
                        principalTable: "mas_Garaje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsuarioDemanda_mas_TipoInmueble_TipoInmuebleId",
                        column: x => x.TipoInmuebleId,
                        principalTable: "mas_TipoInmueble",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsuarioDemanda_mas_TipoMoneda_TipoMonedaId",
                        column: x => x.TipoMonedaId,
                        principalTable: "mas_TipoMoneda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsuarioDemanda_mas_TipoNegocio_TipoNegocioId",
                        column: x => x.TipoNegocioId,
                        principalTable: "mas_TipoNegocio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsuarioDemanda_mas_ZonaBarrio_ZonaBarrioId",
                        column: x => x.ZonaBarrioId,
                        principalTable: "mas_ZonaBarrio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsuarioDemanda_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioDemandaCarExterna",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    UsuarioDemandaId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    CaracteristicaExternaId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioDemandaCarExterna", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioDemandaCarExterna_mas_CaracteristicaExterna_CaracteristicaExternaId",
                        column: x => x.CaracteristicaExternaId,
                        principalTable: "mas_CaracteristicaExterna",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsuarioDemandaCarExterna_Usuario_UsuarioDemandaId",
                        column: x => x.UsuarioDemandaId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioDemandaCarInterna",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    UsuarioDemandaId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    CaracteristicaInternaId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioDemandaCarInterna", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioDemandaCarInterna_mas_CaracteristicaInterna_CaracteristicaInternaId",
                        column: x => x.CaracteristicaInternaId,
                        principalTable: "mas_CaracteristicaInterna",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsuarioDemandaCarInterna_Usuario_UsuarioDemandaId",
                        column: x => x.UsuarioDemandaId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioDocumentoEmpleado",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    ExtractoBancario3meses = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CertificadoLaboral = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    DeclaracionRenta2UltimosAnos = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CopiaDocumentoIdentidad = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioDocumentoEmpleado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioDocumentoEmpleado_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioDocumentoIndependiente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    ExtractoBancario3meses = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    DeclaracionRenta2UltimosAnos = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CertificadoCamaraComercio = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CopiaDocumentoIdentidad = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioDocumentoIndependiente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioDocumentoIndependiente_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioDocumentoJuridico",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    ExtractoBancario = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    DeclaracionRenta = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CertificadoCamaraComercio = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    EstadosFinancieros = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CopiaCedulaRepresentanteLegal = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioDocumentoJuridico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioDocumentoJuridico_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioDocumentoPensionado",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    ExtractoBancario3meses = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CertificadoPagoPension = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CopiaDocumentoIdentidad = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioDocumentoPensionado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioDocumentoPensionado_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioEducacion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    InstitucionUniversidad = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    EstudiaActualmente = table.Column<bool>(type: "bit", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFinalizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioEducacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioEducacion_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioExperienciaLaboral",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    NombreEmpresa = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Cargo = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    TrabajaActualmente = table.Column<bool>(type: "bit", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFinalizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioExperienciaLaboral", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioExperienciaLaboral_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioMultimedia",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    URLImagen = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioMultimedia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioMultimedia_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioProveedor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CiudadId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    PaginaWeb = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    URLFacebook = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    URLInstagram = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioProveedor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioProveedor_mas_Ciudad_CiudadId",
                        column: x => x.CiudadId,
                        principalTable: "mas_Ciudad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsuarioProveedor_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioRedSocial",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    URLFacebook = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    URLTwitter = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    URLLinkedIn = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    URLInstagram = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioRedSocial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioRedSocial_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioServicio",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    ServicioId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioServicio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioServicio_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InmuebleCaracteristicaExterna",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    InmuebleId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    CaracteristicaExternaId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InmuebleCaracteristicaExterna", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InmuebleCaracteristicaExterna_Inmueble_InmuebleId",
                        column: x => x.InmuebleId,
                        principalTable: "Inmueble",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InmuebleCaracteristicaExterna_mas_CaracteristicaExterna_CaracteristicaExternaId",
                        column: x => x.CaracteristicaExternaId,
                        principalTable: "mas_CaracteristicaExterna",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InmuebleCaracteristicaInterna",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    InmuebleId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    CaracteristicaInternaId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InmuebleCaracteristicaInterna", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InmuebleCaracteristicaInterna_Inmueble_InmuebleId",
                        column: x => x.InmuebleId,
                        principalTable: "Inmueble",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InmuebleCaracteristicaInterna_mas_CaracteristicaInterna_CaracteristicaInternaId",
                        column: x => x.CaracteristicaInternaId,
                        principalTable: "mas_CaracteristicaInterna",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InmuebleCompartir",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    InmuebleId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    Asunto = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InmuebleCompartir", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InmuebleCompartir_Inmueble_InmuebleId",
                        column: x => x.InmuebleId,
                        principalTable: "Inmueble",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InmuebleCompartir_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InmuebleDocumentacion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    InmuebleId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    CopiaCedula = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CertificadoCamaraComercio = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CopiaEscrituraCompraventa = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CopiaPromesaCompraventa = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    RUT = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CertificadoLibertad = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    UltimoPagoImpuestoPredial = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CopiaRecibosServiciosPublicosPagos = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    PazSalvoAdministración = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    FirmaContratoAdministración = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    EntregaCartaInstrucciones = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    ContratoCompraAlquiler = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InmuebleDocumentacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InmuebleDocumentacion_Inmueble_InmuebleId",
                        column: x => x.InmuebleId,
                        principalTable: "Inmueble",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InmuebleMultimedia",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    InmuebleId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    URLVideo = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    URLTour360 = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InmuebleMultimedia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InmuebleMultimedia_Inmueble_InmuebleId",
                        column: x => x.InmuebleId,
                        principalTable: "Inmueble",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InmuebleMultimediaImagen",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    InmuebleId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    URLImagen = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InmuebleMultimediaImagen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InmuebleMultimediaImagen_Inmueble_InmuebleId",
                        column: x => x.InmuebleId,
                        principalTable: "Inmueble",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InmuebleNegociacion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    InmuebleId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    TipoNegocioId = table.Column<int>(type: "int", nullable: false),
                    TipoMonedaId = table.Column<int>(type: "int", nullable: false),
                    PrecioVenta = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrecioAlquiler = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TiempoId = table.Column<int>(type: "int", nullable: false),
                    ValorAdministracion = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TienePorcentajePrecio = table.Column<bool>(type: "bit", nullable: false),
                    ValorPorcentajePrecio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TieneCantIdadFija = table.Column<bool>(type: "bit", nullable: false),
                    ValorCantIdadFija = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TieneContratoExclusivIdad = table.Column<bool>(type: "bit", nullable: false),
                    FechaExpiracionContrato = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InmuebleNegociacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InmuebleNegociacion_Inmueble_InmuebleId",
                        column: x => x.InmuebleId,
                        principalTable: "Inmueble",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InmuebleNegociacion_mas_Tiempo_TiempoId",
                        column: x => x.TiempoId,
                        principalTable: "mas_Tiempo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InmuebleNegociacion_mas_TipoMoneda_TipoMonedaId",
                        column: x => x.TipoMonedaId,
                        principalTable: "mas_TipoMoneda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InmuebleNegociacion_mas_TipoNegocio_TipoNegocioId",
                        column: x => x.TipoNegocioId,
                        principalTable: "mas_TipoNegocio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InmuebleUsuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    InmuebleId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    TipoClienteId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InmuebleUsuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InmuebleUsuario_Inmueble_InmuebleId",
                        column: x => x.InmuebleId,
                        principalTable: "Inmueble",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InmuebleUsuario_mas_TipoCliente_TipoClienteId",
                        column: x => x.TipoClienteId,
                        principalTable: "mas_TipoCliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InmuebleUsuario_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProyectoDocumento",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    InmuebleId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    URLDocumento = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProyectoDocumento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProyectoDocumento_Inmueble_InmuebleId",
                        column: x => x.InmuebleId,
                        principalTable: "Inmueble",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProyectoInmueble",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    InmuebleId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProyectoInmueble", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProyectoInmueble_Inmueble_InmuebleId",
                        column: x => x.InmuebleId,
                        principalTable: "Inmueble",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProyectoInversionista",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    InmuebleId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    UsuarioInversionistaId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProyectoInversionista", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProyectoInversionista_Inmueble_InmuebleId",
                        column: x => x.InmuebleId,
                        principalTable: "Inmueble",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProyectoInversionista_Usuario_UsuarioInversionistaId",
                        column: x => x.UsuarioInversionistaId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioInmueble",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    InmuebleId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioInmueble", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioInmueble_Inmueble_InmuebleId",
                        column: x => x.InmuebleId,
                        principalTable: "Inmueble",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsuarioInmueble_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inmueble_AlcobaId",
                table: "Inmueble",
                column: "AlcobaId");

            migrationBuilder.CreateIndex(
                name: "IX_Inmueble_BanoId",
                table: "Inmueble",
                column: "BanoId");

            migrationBuilder.CreateIndex(
                name: "IX_Inmueble_CiudadId",
                table: "Inmueble",
                column: "CiudadId");

            migrationBuilder.CreateIndex(
                name: "IX_Inmueble_EstadoFisicoPropiedadId",
                table: "Inmueble",
                column: "EstadoFisicoPropiedadId");

            migrationBuilder.CreateIndex(
                name: "IX_Inmueble_EstadoPublicacionId",
                table: "Inmueble",
                column: "EstadoPublicacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Inmueble_EstratoId",
                table: "Inmueble",
                column: "EstratoId");

            migrationBuilder.CreateIndex(
                name: "IX_Inmueble_GarajeId",
                table: "Inmueble",
                column: "GarajeId");

            migrationBuilder.CreateIndex(
                name: "IX_Inmueble_GestorInmuebleId",
                table: "Inmueble",
                column: "GestorInmuebleId");

            migrationBuilder.CreateIndex(
                name: "IX_Inmueble_PisoId",
                table: "Inmueble",
                column: "PisoId");

            migrationBuilder.CreateIndex(
                name: "IX_Inmueble_TipoInmuebleId",
                table: "Inmueble",
                column: "TipoInmuebleId");

            migrationBuilder.CreateIndex(
                name: "IX_Inmueble_ZonaBarrioId",
                table: "Inmueble",
                column: "ZonaBarrioId");

            migrationBuilder.CreateIndex(
                name: "IX_InmuebleCaracteristicaExterna_CaracteristicaExternaId",
                table: "InmuebleCaracteristicaExterna",
                column: "CaracteristicaExternaId");

            migrationBuilder.CreateIndex(
                name: "IX_InmuebleCaracteristicaExterna_InmuebleId",
                table: "InmuebleCaracteristicaExterna",
                column: "InmuebleId");

            migrationBuilder.CreateIndex(
                name: "IX_InmuebleCaracteristicaInterna_CaracteristicaInternaId",
                table: "InmuebleCaracteristicaInterna",
                column: "CaracteristicaInternaId");

            migrationBuilder.CreateIndex(
                name: "IX_InmuebleCaracteristicaInterna_InmuebleId",
                table: "InmuebleCaracteristicaInterna",
                column: "InmuebleId");

            migrationBuilder.CreateIndex(
                name: "IX_InmuebleCompartir_InmuebleId",
                table: "InmuebleCompartir",
                column: "InmuebleId");

            migrationBuilder.CreateIndex(
                name: "IX_InmuebleCompartir_UsuarioId",
                table: "InmuebleCompartir",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_InmuebleDocumentacion_InmuebleId",
                table: "InmuebleDocumentacion",
                column: "InmuebleId");

            migrationBuilder.CreateIndex(
                name: "IX_InmuebleMultimedia_InmuebleId",
                table: "InmuebleMultimedia",
                column: "InmuebleId");

            migrationBuilder.CreateIndex(
                name: "IX_InmuebleMultimediaImagen_InmuebleId",
                table: "InmuebleMultimediaImagen",
                column: "InmuebleId");

            migrationBuilder.CreateIndex(
                name: "IX_InmuebleNegociacion_InmuebleId",
                table: "InmuebleNegociacion",
                column: "InmuebleId");

            migrationBuilder.CreateIndex(
                name: "IX_InmuebleNegociacion_TiempoId",
                table: "InmuebleNegociacion",
                column: "TiempoId");

            migrationBuilder.CreateIndex(
                name: "IX_InmuebleNegociacion_TipoMonedaId",
                table: "InmuebleNegociacion",
                column: "TipoMonedaId");

            migrationBuilder.CreateIndex(
                name: "IX_InmuebleNegociacion_TipoNegocioId",
                table: "InmuebleNegociacion",
                column: "TipoNegocioId");

            migrationBuilder.CreateIndex(
                name: "IX_InmuebleUsuario_InmuebleId",
                table: "InmuebleUsuario",
                column: "InmuebleId");

            migrationBuilder.CreateIndex(
                name: "IX_InmuebleUsuario_TipoClienteId",
                table: "InmuebleUsuario",
                column: "TipoClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_InmuebleUsuario_UsuarioId",
                table: "InmuebleUsuario",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Proyecto_EstadoProyectoId",
                table: "Proyecto",
                column: "EstadoProyectoId");

            migrationBuilder.CreateIndex(
                name: "IX_Proyecto_TipoInmuebleId",
                table: "Proyecto",
                column: "TipoInmuebleId");

            migrationBuilder.CreateIndex(
                name: "IX_Proyecto_TipoMonedaId",
                table: "Proyecto",
                column: "TipoMonedaId");

            migrationBuilder.CreateIndex(
                name: "IX_Proyecto_TipoNegocioId",
                table: "Proyecto",
                column: "TipoNegocioId");

            migrationBuilder.CreateIndex(
                name: "IX_Proyecto_UsuarioEncargadoId",
                table: "Proyecto",
                column: "UsuarioEncargadoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProyectoDocumento_InmuebleId",
                table: "ProyectoDocumento",
                column: "InmuebleId");

            migrationBuilder.CreateIndex(
                name: "IX_ProyectoInmueble_InmuebleId",
                table: "ProyectoInmueble",
                column: "InmuebleId");

            migrationBuilder.CreateIndex(
                name: "IX_ProyectoInversionista_InmuebleId",
                table: "ProyectoInversionista",
                column: "InmuebleId");

            migrationBuilder.CreateIndex(
                name: "IX_ProyectoInversionista_UsuarioInversionistaId",
                table: "ProyectoInversionista",
                column: "UsuarioInversionistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_CiudadId",
                table: "Usuario",
                column: "CiudadId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_EstadoUsuarioId",
                table: "Usuario",
                column: "EstadoUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_MedioCaptacionId",
                table: "Usuario",
                column: "MedioCaptacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_TipoIdentificacionId",
                table: "Usuario",
                column: "TipoIdentificacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_TipoPersonaId",
                table: "Usuario",
                column: "TipoPersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_TipoUsuarioId",
                table: "Usuario",
                column: "TipoUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_UsuarioEncargadoId",
                table: "Usuario",
                column: "UsuarioEncargadoId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioDemanda_BanoId",
                table: "UsuarioDemanda",
                column: "BanoId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioDemanda_CiudadId",
                table: "UsuarioDemanda",
                column: "CiudadId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioDemanda_GarajeId",
                table: "UsuarioDemanda",
                column: "GarajeId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioDemanda_TipoInmuebleId",
                table: "UsuarioDemanda",
                column: "TipoInmuebleId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioDemanda_TipoMonedaId",
                table: "UsuarioDemanda",
                column: "TipoMonedaId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioDemanda_TipoNegocioId",
                table: "UsuarioDemanda",
                column: "TipoNegocioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioDemanda_UsuarioId",
                table: "UsuarioDemanda",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioDemanda_ZonaBarrioId",
                table: "UsuarioDemanda",
                column: "ZonaBarrioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioDemandaCarExterna_CaracteristicaExternaId",
                table: "UsuarioDemandaCarExterna",
                column: "CaracteristicaExternaId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioDemandaCarExterna_UsuarioDemandaId",
                table: "UsuarioDemandaCarExterna",
                column: "UsuarioDemandaId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioDemandaCarInterna_CaracteristicaInternaId",
                table: "UsuarioDemandaCarInterna",
                column: "CaracteristicaInternaId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioDemandaCarInterna_UsuarioDemandaId",
                table: "UsuarioDemandaCarInterna",
                column: "UsuarioDemandaId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioDocumentoEmpleado_UsuarioId",
                table: "UsuarioDocumentoEmpleado",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioDocumentoIndependiente_UsuarioId",
                table: "UsuarioDocumentoIndependiente",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioDocumentoJuridico_UsuarioId",
                table: "UsuarioDocumentoJuridico",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioDocumentoPensionado_UsuarioId",
                table: "UsuarioDocumentoPensionado",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioEducacion_UsuarioId",
                table: "UsuarioEducacion",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioExperienciaLaboral_UsuarioId",
                table: "UsuarioExperienciaLaboral",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioInmueble_InmuebleId",
                table: "UsuarioInmueble",
                column: "InmuebleId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioInmueble_UsuarioId",
                table: "UsuarioInmueble",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioMultimedia_UsuarioId",
                table: "UsuarioMultimedia",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioProveedor_CiudadId",
                table: "UsuarioProveedor",
                column: "CiudadId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioProveedor_UsuarioId",
                table: "UsuarioProveedor",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRedSocial_UsuarioId",
                table: "UsuarioRedSocial",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioServicio_UsuarioId",
                table: "UsuarioServicio",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InmuebleCaracteristicaExterna");

            migrationBuilder.DropTable(
                name: "InmuebleCaracteristicaInterna");

            migrationBuilder.DropTable(
                name: "InmuebleCompartir");

            migrationBuilder.DropTable(
                name: "InmuebleDocumentacion");

            migrationBuilder.DropTable(
                name: "InmuebleMultimedia");

            migrationBuilder.DropTable(
                name: "InmuebleMultimediaImagen");

            migrationBuilder.DropTable(
                name: "InmuebleNegociacion");

            migrationBuilder.DropTable(
                name: "InmuebleUsuario");

            migrationBuilder.DropTable(
                name: "Proyecto");

            migrationBuilder.DropTable(
                name: "ProyectoDocumento");

            migrationBuilder.DropTable(
                name: "ProyectoInmueble");

            migrationBuilder.DropTable(
                name: "ProyectoInversionista");

            migrationBuilder.DropTable(
                name: "UsuarioDemanda");

            migrationBuilder.DropTable(
                name: "UsuarioDemandaCarExterna");

            migrationBuilder.DropTable(
                name: "UsuarioDemandaCarInterna");

            migrationBuilder.DropTable(
                name: "UsuarioDocumentoEmpleado");

            migrationBuilder.DropTable(
                name: "UsuarioDocumentoIndependiente");

            migrationBuilder.DropTable(
                name: "UsuarioDocumentoJuridico");

            migrationBuilder.DropTable(
                name: "UsuarioDocumentoPensionado");

            migrationBuilder.DropTable(
                name: "UsuarioEducacion");

            migrationBuilder.DropTable(
                name: "UsuarioExperienciaLaboral");

            migrationBuilder.DropTable(
                name: "UsuarioInmueble");

            migrationBuilder.DropTable(
                name: "UsuarioMultimedia");

            migrationBuilder.DropTable(
                name: "UsuarioProveedor");

            migrationBuilder.DropTable(
                name: "UsuarioRedSocial");

            migrationBuilder.DropTable(
                name: "UsuarioServicio");

            migrationBuilder.DropTable(
                name: "Inmueble");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "mas_EstadoUsuario");

            migrationBuilder.DropTable(
                name: "TipoIdentificacion");

            migrationBuilder.CreateTable(
                name: "mas_EstadoCliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    Descripcion = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Default"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mas_EstadoCliente", x => x.Id);
                });
        }
    }
}
