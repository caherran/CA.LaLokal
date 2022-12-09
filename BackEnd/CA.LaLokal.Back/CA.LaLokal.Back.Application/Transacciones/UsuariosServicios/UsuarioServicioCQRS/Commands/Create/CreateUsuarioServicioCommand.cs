using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosServicios;
using CA.GuidGenerator;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosServicios.UsuarioServicioCQRS.Commands.Create
{
    public class CreateUsuarioServicioCommand : IRequest<ResponseBase<Guid>>, IMapFrom<UsuarioServicio>
    {
        public Guid UsuarioId { get; set; }
public int ServicioId { get; set; }

    }

    public class CreateUsuarioServicioCommandHandler : IRequestHandler<CreateUsuarioServicioCommand, ResponseBase<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<UsuarioServicio> _repository;
        private readonly IMapper _mapper;

        public CreateUsuarioServicioCommandHandler(IUnitOfWork unitOfWork, IRepository<UsuarioServicio> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<Guid>> Handle(CreateUsuarioServicioCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<UsuarioServicio>(request);
            entity.Id = SequentialGuid.Create();
            _repository.Insert(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new ResponseBase<Guid>(entity.Id);
        }
    }
}
