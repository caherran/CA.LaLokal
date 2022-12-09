using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosDocumentosPensionados.UsuarioDocumentoPensionadoCQRS.Commands.Update
{
    public class UpdateUsuarioDocumentoPensionadoCommandValidator : AbstractValidator<UpdateUsuarioDocumentoPensionadoCommand>
    {
        public UpdateUsuarioDocumentoPensionadoCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Id).NotEmpty();
RuleFor(p => p.UsuarioId).NotEmpty();
RuleFor(p => p.ExtractoBancario3meses).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));
RuleFor(p => p.CertificadoPagoPension).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));
RuleFor(p => p.CopiaDocumentoIdentidad).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));

        }
    }
}