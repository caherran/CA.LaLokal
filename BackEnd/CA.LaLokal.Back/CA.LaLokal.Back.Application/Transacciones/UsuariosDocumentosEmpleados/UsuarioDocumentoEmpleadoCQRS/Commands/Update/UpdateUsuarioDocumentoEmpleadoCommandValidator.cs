using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosDocumentosEmpleados.UsuarioDocumentoEmpleadoCQRS.Commands.Update
{
    public class UpdateUsuarioDocumentoEmpleadoCommandValidator : AbstractValidator<UpdateUsuarioDocumentoEmpleadoCommand>
    {
        public UpdateUsuarioDocumentoEmpleadoCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Id).NotEmpty();
RuleFor(p => p.UsuarioId).NotEmpty();
RuleFor(p => p.ExtractoBancario3meses).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));
RuleFor(p => p.CertificadoLaboral).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));
RuleFor(p => p.DeclaracionRenta2UltimosAnos).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));
RuleFor(p => p.CopiaDocumentoIdentidad).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));

        }
    }
}