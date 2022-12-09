using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.InmueblesCaracteristicasExternas;
using CA.GuidGenerator;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Transacciones.InmueblesCaracteristicasExternas.InmuebleCaracteristicaExternaCQRS.Commands.Create
{
    public class CreateInmuebleCaracteristicaExternaCommand : IRequest<ResponseBase<Guid>>, IMapFrom<InmuebleCaracteristicaExterna>
    {
        public Guid InmuebleId { get; set; }
public int CaracteristicaExternaId { get; set; }

    }

    public class CreateInmuebleCaracteristicaExternaCommandHandler : IRequestHandler<CreateInmuebleCaracteristicaExternaCommand, ResponseBase<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<InmuebleCaracteristicaExterna> _repository;
        private readonly IMapper _mapper;

        public CreateInmuebleCaracteristicaExternaCommandHandler(IUnitOfWork unitOfWork, IRepository<InmuebleCaracteristicaExterna> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<Guid>> Handle(CreateInmuebleCaracteristicaExternaCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<InmuebleCaracteristicaExterna>(request);
            entity.Id = SequentialGuid.Create();
            _repository.Insert(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new ResponseBase<Guid>(entity.Id);
        }
    }
}
