using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Transacciones.Proyectos.ProyectoCQRS.Commands.Update
{
    public class UpdateProyectoCommandValidator : AbstractValidator<UpdateProyectoCommand>
    {
        public UpdateProyectoCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Id).NotEmpty();
RuleFor(p => p.UsuarioEncargadoId).NotEmpty();
RuleFor(p => p.Codigo).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));
RuleFor(p => p.Descripcion).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));
RuleFor(p => p.EstadoProyectoId).NotEmpty();
RuleFor(p => p.TipoInmuebleId).NotEmpty();
RuleFor(p => p.TipoNegocioId).NotEmpty();
RuleFor(p => p.TipoMonedaId).NotEmpty();
RuleFor(p => p.MontoTotal).NotEmpty();
RuleFor(p => p.CantIdadInversionistas).NotEmpty();
RuleFor(p => p.MontoMinimoInversion).NotEmpty();
RuleFor(p => p.MontoMaximoInversion).NotEmpty();
RuleFor(p => p.RentabilIdadTotal).NotEmpty();
RuleFor(p => p.RentabilIdadAnalizada).NotEmpty();
RuleFor(p => p.PlazoRetornoEsperado).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));
RuleFor(p => p.TotalAFinanciar).NotEmpty();
RuleFor(p => p.CostoProyecto).NotEmpty();
RuleFor(p => p.IngresoEstimadoVenta).NotEmpty();
RuleFor(p => p.RentabilIdad).NotEmpty();
RuleFor(p => p.CreacionSpA).NotEmpty();
RuleFor(p => p.InscripciónSpA).NotEmpty();
RuleFor(p => p.EstudioTítulos).NotEmpty();
RuleFor(p => p.PromesaEscrituraCompra).NotEmpty();
RuleFor(p => p.InscripciónPropiedadCBR).NotEmpty();
RuleFor(p => p.ContabilIdadRentaAnual).NotEmpty();
RuleFor(p => p.ContabilIdadMensual).NotEmpty();
RuleFor(p => p.Contribuciones).NotEmpty();
RuleFor(p => p.PatenteComercialSpA).NotEmpty();
RuleFor(p => p.CompraTerreno).NotEmpty();
RuleFor(p => p.ComisiónCorretajeCompra).NotEmpty();
RuleFor(p => p.ProyectoParcelación).NotEmpty();
RuleFor(p => p.MarketingVenta).NotEmpty();
RuleFor(p => p.FondoReservaProyecto).NotEmpty();
RuleFor(p => p.PromesaEscrituraVenta).NotEmpty();
RuleFor(p => p.CierreSpA).NotEmpty();

        }
    }
}