using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosDocumentosPensionados;
using CA.GuidGenerator;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosDocumentosPensionados.UsuarioDocumentoPensionadoCQRS.Commands.Create
{
    public class CreateUsuarioDocumentoPensionadoCommand : IRequest<ResponseBase<Guid>>, IMapFrom<UsuarioDocumentoPensionado>
    {
        public Guid UsuarioId { get; set; }
public string ExtractoBancario3meses { get; set; }
public string CertificadoPagoPension { get; set; }
public string CopiaDocumentoIdentidad { get; set; }

    }

    public class CreateUsuarioDocumentoPensionadoCommandHandler : IRequestHandler<CreateUsuarioDocumentoPensionadoCommand, ResponseBase<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<UsuarioDocumentoPensionado> _repository;
        private readonly IMapper _mapper;

        public CreateUsuarioDocumentoPensionadoCommandHandler(IUnitOfWork unitOfWork, IRepository<UsuarioDocumentoPensionado> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<Guid>> Handle(CreateUsuarioDocumentoPensionadoCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<UsuarioDocumentoPensionado>(request);
            entity.Id = SequentialGuid.Create();
            _repository.Insert(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new ResponseBase<Guid>(entity.Id);
        }
    }
}
