using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosDocumentosEmpleados;
using CA.GuidGenerator;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosDocumentosEmpleados.UsuarioDocumentoEmpleadoCQRS.Commands.Create
{
    public class CreateUsuarioDocumentoEmpleadoCommand : IRequest<ResponseBase<Guid>>, IMapFrom<UsuarioDocumentoEmpleado>
    {
        public Guid UsuarioId { get; set; }
public string ExtractoBancario3meses { get; set; }
public string CertificadoLaboral { get; set; }
public string DeclaracionRenta2UltimosAnos { get; set; }
public string CopiaDocumentoIdentidad { get; set; }

    }

    public class CreateUsuarioDocumentoEmpleadoCommandHandler : IRequestHandler<CreateUsuarioDocumentoEmpleadoCommand, ResponseBase<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<UsuarioDocumentoEmpleado> _repository;
        private readonly IMapper _mapper;

        public CreateUsuarioDocumentoEmpleadoCommandHandler(IUnitOfWork unitOfWork, IRepository<UsuarioDocumentoEmpleado> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<Guid>> Handle(CreateUsuarioDocumentoEmpleadoCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<UsuarioDocumentoEmpleado>(request);
            entity.Id = SequentialGuid.Create();
            _repository.Insert(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new ResponseBase<Guid>(entity.Id);
        }
    }
}
