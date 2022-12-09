using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.InmueblesMultimediaImagenes;
using CA.GuidGenerator;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Transacciones.InmueblesMultimediaImagenes.InmuebleMultimediaImagenCQRS.Commands.Create
{
    public class CreateInmuebleMultimediaImagenCommand : IRequest<ResponseBase<Guid>>, IMapFrom<InmuebleMultimediaImagen>
    {
        public Guid InmuebleId { get; set; }
public string URLImagen { get; set; }

    }

    public class CreateInmuebleMultimediaImagenCommandHandler : IRequestHandler<CreateInmuebleMultimediaImagenCommand, ResponseBase<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<InmuebleMultimediaImagen> _repository;
        private readonly IMapper _mapper;

        public CreateInmuebleMultimediaImagenCommandHandler(IUnitOfWork unitOfWork, IRepository<InmuebleMultimediaImagen> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<Guid>> Handle(CreateInmuebleMultimediaImagenCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<InmuebleMultimediaImagen>(request);
            entity.Id = SequentialGuid.Create();
            _repository.Insert(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new ResponseBase<Guid>(entity.Id);
        }
    }
}
