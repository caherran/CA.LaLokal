using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosDocumentosPensionados;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosDocumentosPensionados.UsuarioDocumentoPensionadoCQRS.Commands.Update
{
    public class UpdateUsuarioDocumentoPensionadoCommand : IRequest<ResponseBase<bool>>, IMapFrom<UsuarioDocumentoPensionado>
    {
        public Guid Id { get; set; }
public Guid UsuarioId { get; set; }
public string ExtractoBancario3meses { get; set; }
public string CertificadoPagoPension { get; set; }
public string CopiaDocumentoIdentidad { get; set; }

    }

    public class UpdateUsuarioDocumentoPensionadoCommandHandler : IRequestHandler<UpdateUsuarioDocumentoPensionadoCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<UsuarioDocumentoPensionado> _repository;
        private readonly IMapper _mapper;

        public UpdateUsuarioDocumentoPensionadoCommandHandler(IUnitOfWork unitOfWork, IRepository<UsuarioDocumentoPensionado> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<bool>> Handle(UpdateUsuarioDocumentoPensionadoCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("UsuarioDocumentoPensionado", request.Id);
            }

            _mapper.Map(request, entity);

            _repository.Update(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
