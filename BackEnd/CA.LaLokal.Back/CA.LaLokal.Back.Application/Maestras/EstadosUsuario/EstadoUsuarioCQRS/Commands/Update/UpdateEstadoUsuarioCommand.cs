using AutoMapper;
using CA.Domain.Auditable.Exceptions;
using CA.LaLokal.Back.Domain.Maestras.EstadosUsuario;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CA.LaLokal.Back.Application.Maestras.EstadosUsuario.EstadoUsuarioCQRS.Commands.Update
{
    public class UpdateEstadoUsuarioCommand : IRequest<ResponseBase<bool>>, IMapFrom<EstadoUsuario>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }

    public class UpdateEstadoClienteCommandHandler : IRequestHandler<UpdateEstadoUsuarioCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<EstadoUsuario> _repository;
        private readonly IMapper _mapper;

        public UpdateEstadoClienteCommandHandler(IUnitOfWork unitOfWork, IRepository<EstadoUsuario> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<bool>> Handle(UpdateEstadoUsuarioCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("EstadoCliente", request.Id);
            }

            _mapper.Map(request, entity);

            _repository.Update(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
