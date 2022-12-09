using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosDocumentosIndependientes;
using CA.GuidGenerator;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosDocumentosIndependientes.UsuarioDocumentoIndependienteCQRS.Commands.Create
{
    public class CreateUsuarioDocumentoIndependienteCommand : IRequest<ResponseBase<Guid>>, IMapFrom<UsuarioDocumentoIndependiente>
    {
        public Guid UsuarioId { get; set; }
public string ExtractoBancario3meses { get; set; }
public string DeclaracionRenta2UltimosAnos { get; set; }
public string CertificadoCamaraComercio { get; set; }
public string CopiaDocumentoIdentidad { get; set; }

    }

    public class CreateUsuarioDocumentoIndependienteCommandHandler : IRequestHandler<CreateUsuarioDocumentoIndependienteCommand, ResponseBase<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<UsuarioDocumentoIndependiente> _repository;
        private readonly IMapper _mapper;

        public CreateUsuarioDocumentoIndependienteCommandHandler(IUnitOfWork unitOfWork, IRepository<UsuarioDocumentoIndependiente> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<Guid>> Handle(CreateUsuarioDocumentoIndependienteCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<UsuarioDocumentoIndependiente>(request);
            entity.Id = SequentialGuid.Create();
            _repository.Insert(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new ResponseBase<Guid>(entity.Id);
        }
    }
}
