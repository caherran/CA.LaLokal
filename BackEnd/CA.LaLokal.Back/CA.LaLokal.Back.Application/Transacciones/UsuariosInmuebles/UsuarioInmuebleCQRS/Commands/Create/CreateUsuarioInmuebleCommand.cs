using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosInmuebles;
using CA.GuidGenerator;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosInmuebles.UsuarioInmuebleCQRS.Commands.Create
{
    public class CreateUsuarioInmuebleCommand : IRequest<ResponseBase<Guid>>, IMapFrom<UsuarioInmueble>
    {
        public Guid UsuarioId { get; set; }
public Guid InmuebleId { get; set; }

    }

    public class CreateUsuarioInmuebleCommandHandler : IRequestHandler<CreateUsuarioInmuebleCommand, ResponseBase<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<UsuarioInmueble> _repository;
        private readonly IMapper _mapper;

        public CreateUsuarioInmuebleCommandHandler(IUnitOfWork unitOfWork, IRepository<UsuarioInmueble> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<Guid>> Handle(CreateUsuarioInmuebleCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<UsuarioInmueble>(request);
            entity.Id = SequentialGuid.Create();
            _repository.Insert(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new ResponseBase<Guid>(entity.Id);
        }
    }
}
