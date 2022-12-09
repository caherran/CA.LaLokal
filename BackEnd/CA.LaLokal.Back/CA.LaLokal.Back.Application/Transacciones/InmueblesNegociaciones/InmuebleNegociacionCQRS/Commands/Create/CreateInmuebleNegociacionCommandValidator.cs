using CA.Util.DependencyInjection;
using FluentValidation;

namespace CA.LaLokal.Back.Application.Transacciones.InmueblesNegociaciones.InmuebleNegociacionCQRS.Commands.Create
{
    public class CreateInmuebleNegociacionCommandValidator : AbstractValidator<CreateInmuebleNegociacionCommand>
    {
        public CreateInmuebleNegociacionCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.InmuebleId).NotEmpty();
            RuleFor(p => p.TipoNegocioId).NotEmpty();
            RuleFor(p => p.TipoMonedaId).NotEmpty();
            RuleFor(p => p.PrecioVenta).NotEmpty();
            RuleFor(p => p.PrecioAlquiler).NotEmpty();
            RuleFor(p => p.TiempoId).NotEmpty();
            RuleFor(p => p.ValorAdministracion).NotEmpty();
            RuleFor(p => p.TienePorcentajePrecio).NotEmpty();
            RuleFor(p => p.ValorPorcentajePrecio).NotEmpty();
            RuleFor(p => p.TieneCantIdadFija).NotEmpty();
            RuleFor(p => p.ValorCantIdadFija).NotEmpty();
            RuleFor(p => p.TieneContratoExclusivIdad).NotEmpty();
            RuleFor(p => p.FechaExpiracionContrato).NotEmpty();

        }
    }
}