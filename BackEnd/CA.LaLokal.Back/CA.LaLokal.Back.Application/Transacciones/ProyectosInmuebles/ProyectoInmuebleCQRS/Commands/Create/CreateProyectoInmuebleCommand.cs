using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.ProyectosInmuebles;
using CA.GuidGenerator;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Transacciones.ProyectosInmuebles.ProyectoInmuebleCQRS.Commands.Create
{
    public class CreateProyectoInmuebleCommand : IRequest<ResponseBase<Guid>>, IMapFrom<ProyectoInmueble>
    {
        public Guid InmuebleId { get; set; }

    }

    public class CreateProyectoInmuebleCommandHandler : IRequestHandler<CreateProyectoInmuebleCommand, ResponseBase<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<ProyectoInmueble> _repository;
        private readonly IMapper _mapper;

        public CreateProyectoInmuebleCommandHandler(IUnitOfWork unitOfWork, IRepository<ProyectoInmueble> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<Guid>> Handle(CreateProyectoInmuebleCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ProyectoInmueble>(request);
            entity.Id = SequentialGuid.Create();
            _repository.Insert(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new ResponseBase<Guid>(entity.Id);
        }
    }
}
