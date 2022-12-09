using FluentValidation;
using CA.Util.DependencyInjection;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosDocumentosJuridicos.UsuarioDocumentoJuridicoCQRS.Commands.Update
{
    public class UpdateUsuarioDocumentoJuridicoCommandValidator : AbstractValidator<UpdateUsuarioDocumentoJuridicoCommand>
    {
        public UpdateUsuarioDocumentoJuridicoCommandValidator(IRegexValidationConstants regexConstants)
        {
            RuleFor(p => p.Id).NotEmpty();
RuleFor(p => p.UsuarioId).NotEmpty();
RuleFor(p => p.ExtractoBancario).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));
RuleFor(p => p.DeclaracionRenta).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));
RuleFor(p => p.CertificadoCamaraComercio).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));
RuleFor(p => p.EstadosFinancieros).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));
RuleFor(p => p.CopiaCedulaRepresentanteLegal).NotEmpty().MaximumLength(80).Matches(regexConstants.GetRegexConstant(IRegexValidationConstants.AlphaNumericRegexConstant));

        }
    }
}