using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.InmueblesCaracteristicasInternas;
using CA.GuidGenerator;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Transacciones.InmueblesCaracteristicasInternas.InmuebleCaracteristicaInternaCQRS.Commands.Create
{
    public class CreateInmuebleCaracteristicaInternaCommand : IRequest<ResponseBase<Guid>>, IMapFrom<InmuebleCaracteristicaInterna>
    {
        public Guid InmuebleId { get; set; }
public int CaracteristicaInternaId { get; set; }

    }

    public class CreateInmuebleCaracteristicaInternaCommandHandler : IRequestHandler<CreateInmuebleCaracteristicaInternaCommand, ResponseBase<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<InmuebleCaracteristicaInterna> _repository;
        private readonly IMapper _mapper;

        public CreateInmuebleCaracteristicaInternaCommandHandler(IUnitOfWork unitOfWork, IRepository<InmuebleCaracteristicaInterna> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<Guid>> Handle(CreateInmuebleCaracteristicaInternaCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<InmuebleCaracteristicaInterna>(request);
            entity.Id = SequentialGuid.Create();
            _repository.Insert(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new ResponseBase<Guid>(entity.Id);
        }
    }
}
