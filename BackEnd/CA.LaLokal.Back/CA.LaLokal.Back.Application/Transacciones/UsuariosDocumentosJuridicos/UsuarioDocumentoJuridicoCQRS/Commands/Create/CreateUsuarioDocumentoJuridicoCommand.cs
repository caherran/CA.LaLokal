using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosDocumentosJuridicos;
using CA.GuidGenerator;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosDocumentosJuridicos.UsuarioDocumentoJuridicoCQRS.Commands.Create
{
    public class CreateUsuarioDocumentoJuridicoCommand : IRequest<ResponseBase<Guid>>, IMapFrom<UsuarioDocumentoJuridico>
    {
        public Guid UsuarioId { get; set; }
public string ExtractoBancario { get; set; }
public string DeclaracionRenta { get; set; }
public string CertificadoCamaraComercio { get; set; }
public string EstadosFinancieros { get; set; }
public string CopiaCedulaRepresentanteLegal { get; set; }

    }

    public class CreateUsuarioDocumentoJuridicoCommandHandler : IRequestHandler<CreateUsuarioDocumentoJuridicoCommand, ResponseBase<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<UsuarioDocumentoJuridico> _repository;
        private readonly IMapper _mapper;

        public CreateUsuarioDocumentoJuridicoCommandHandler(IUnitOfWork unitOfWork, IRepository<UsuarioDocumentoJuridico> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<Guid>> Handle(CreateUsuarioDocumentoJuridicoCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<UsuarioDocumentoJuridico>(request);
            entity.Id = SequentialGuid.Create();
            _repository.Insert(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new ResponseBase<Guid>(entity.Id);
        }
    }
}
