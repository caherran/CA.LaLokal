using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.ProyectosDocumentos;
using CA.GuidGenerator;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Transacciones.ProyectosDocumentos.ProyectoDocumentoCQRS.Commands.Create
{
    public class CreateProyectoDocumentoCommand : IRequest<ResponseBase<Guid>>, IMapFrom<ProyectoDocumento>
    {
        public Guid InmuebleId { get; set; }
public string Descripcion { get; set; }
public string URLDocumento { get; set; }

    }

    public class CreateProyectoDocumentoCommandHandler : IRequestHandler<CreateProyectoDocumentoCommand, ResponseBase<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<ProyectoDocumento> _repository;
        private readonly IMapper _mapper;

        public CreateProyectoDocumentoCommandHandler(IUnitOfWork unitOfWork, IRepository<ProyectoDocumento> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<Guid>> Handle(CreateProyectoDocumentoCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ProyectoDocumento>(request);
            entity.Id = SequentialGuid.Create();
            _repository.Insert(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new ResponseBase<Guid>(entity.Id);
        }
    }
}
