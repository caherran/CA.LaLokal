using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.InmueblesMultimedia;
using CA.GuidGenerator;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Transacciones.InmueblesMultimedia.InmuebleMultimediaCQRS.Commands.Create
{
    public class CreateInmuebleMultimediaCommand : IRequest<ResponseBase<Guid>>, IMapFrom<InmuebleMultimedia>
    {
        public Guid InmuebleId { get; set; }
public string URLVideo { get; set; }
public string URLTour360 { get; set; }

    }

    public class CreateInmuebleMultimediaCommandHandler : IRequestHandler<CreateInmuebleMultimediaCommand, ResponseBase<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<InmuebleMultimedia> _repository;
        private readonly IMapper _mapper;

        public CreateInmuebleMultimediaCommandHandler(IUnitOfWork unitOfWork, IRepository<InmuebleMultimedia> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<Guid>> Handle(CreateInmuebleMultimediaCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<InmuebleMultimedia>(request);
            entity.Id = SequentialGuid.Create();
            _repository.Insert(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new ResponseBase<Guid>(entity.Id);
        }
    }
}
