using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosMultimedia;
using CA.GuidGenerator;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosMultimedia.UsuarioMultimediaCQRS.Commands.Create
{
    public class CreateUsuarioMultimediaCommand : IRequest<ResponseBase<Guid>>, IMapFrom<UsuarioMultimedia>
    {
        public Guid UsuarioId { get; set; }
public string URLImagen { get; set; }

    }

    public class CreateUsuarioMultimediaCommandHandler : IRequestHandler<CreateUsuarioMultimediaCommand, ResponseBase<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<UsuarioMultimedia> _repository;
        private readonly IMapper _mapper;

        public CreateUsuarioMultimediaCommandHandler(IUnitOfWork unitOfWork, IRepository<UsuarioMultimedia> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<Guid>> Handle(CreateUsuarioMultimediaCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<UsuarioMultimedia>(request);
            entity.Id = SequentialGuid.Create();
            _repository.Insert(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new ResponseBase<Guid>(entity.Id);
        }
    }
}
