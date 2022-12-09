using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosDocumentosIndependientes.UsuarioDocumentoIndependienteCQRS.Commands.Create
{
    public class CreateUsuarioDocumentoIndependienteCommandValidator : AbstractValidator<CreateUsuarioDocumentoIndependienteCommand>
    {
        public CreateUsuarioDocumentoIndependienteCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.UsuarioId).NotEmpty();
RuleFor(p => p.ExtractoBancario3meses).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));
RuleFor(p => p.DeclaracionRenta2UltimosAnos).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));
RuleFor(p => p.CertificadoCamaraComercio).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));
RuleFor(p => p.CopiaDocumentoIdentidad).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));

        }
    }
}