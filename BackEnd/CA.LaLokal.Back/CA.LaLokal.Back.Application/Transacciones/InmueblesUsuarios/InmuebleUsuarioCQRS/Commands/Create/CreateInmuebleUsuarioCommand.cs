using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.InmueblesUsuarios;
using CA.GuidGenerator;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Transacciones.InmueblesUsuarios.InmuebleUsuarioCQRS.Commands.Create
{
    public class CreateInmuebleUsuarioCommand : IRequest<ResponseBase<Guid>>, IMapFrom<InmuebleUsuario>
    {
        public Guid InmuebleId { get; set; }
public Guid UsuarioId { get; set; }
public int TipoClienteId { get; set; }

    }

    public class CreateInmuebleUsuarioCommandHandler : IRequestHandler<CreateInmuebleUsuarioCommand, ResponseBase<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<InmuebleUsuario> _repository;
        private readonly IMapper _mapper;

        public CreateInmuebleUsuarioCommandHandler(IUnitOfWork unitOfWork, IRepository<InmuebleUsuario> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<Guid>> Handle(CreateInmuebleUsuarioCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<InmuebleUsuario>(request);
            entity.Id = SequentialGuid.Create();
            _repository.Insert(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new ResponseBase<Guid>(entity.Id);
        }
    }
}
