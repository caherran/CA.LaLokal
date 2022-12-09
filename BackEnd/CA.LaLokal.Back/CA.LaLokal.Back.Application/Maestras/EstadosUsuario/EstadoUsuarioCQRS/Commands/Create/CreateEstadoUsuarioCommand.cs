using AutoMapper;
using CA.LaLokal.Back.Domain.Maestras.EstadosUsuario;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CA.LaLokal.Back.Application.Maestras.EstadosUsuario.EstadoUsuarioCQRS.Commands.Create
{
    public class CreateEstadoUsuarioCommand : IRequest<ResponseBase<int>>, IMapFrom<EstadoUsuario>
    {
        public string Descripcion { get; set; }

    }

    public class CreateEstadoClienteCommandHandler : IRequestHandler<CreateEstadoUsuarioCommand, ResponseBase<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<EstadoUsuario> _repository;
        private readonly IMapper _mapper;

        public CreateEstadoClienteCommandHandler(IUnitOfWork unitOfWork, IRepository<EstadoUsuario> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<int>> Handle(CreateEstadoUsuarioCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<EstadoUsuario>(request);
            //entity.Id = SequentialGuid.Create();
            _repository.Insert(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new ResponseBase<int>(entity.Id);
        }
    }
}
