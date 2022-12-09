using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosDocumentosIndependientes.UsuarioDocumentoIndependienteCQRS.Commands.Update
{
    public class UpdateUsuarioDocumentoIndependienteCommandValidator : AbstractValidator<UpdateUsuarioDocumentoIndependienteCommand>
    {
        public UpdateUsuarioDocumentoIndependienteCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Id).NotEmpty();
RuleFor(p => p.UsuarioId).NotEmpty();
RuleFor(p => p.ExtractoBancario3meses).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));
RuleFor(p => p.DeclaracionRenta2UltimosAnos).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));
RuleFor(p => p.CertificadoCamaraComercio).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));
RuleFor(p => p.CopiaDocumentoIdentidad).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));

        }
    }
}