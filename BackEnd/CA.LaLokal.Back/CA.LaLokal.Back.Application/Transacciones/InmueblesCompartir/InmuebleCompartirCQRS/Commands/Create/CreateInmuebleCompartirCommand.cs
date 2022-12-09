using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.InmueblesCompartir;
using CA.GuidGenerator;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Transacciones.InmueblesCompartir.InmuebleCompartirCQRS.Commands.Create
{
    public class CreateInmuebleCompartirCommand : IRequest<ResponseBase<Guid>>, IMapFrom<InmuebleCompartir>
    {
        public Guid InmuebleId { get; set; }
public Guid UsuarioId { get; set; }
public string Asunto { get; set; }

    }

    public class CreateInmuebleCompartirCommandHandler : IRequestHandler<CreateInmuebleCompartirCommand, ResponseBase<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<InmuebleCompartir> _repository;
        private readonly IMapper _mapper;

        public CreateInmuebleCompartirCommandHandler(IUnitOfWork unitOfWork, IRepository<InmuebleCompartir> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<Guid>> Handle(CreateInmuebleCompartirCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<InmuebleCompartir>(request);
            entity.Id = SequentialGuid.Create();
            _repository.Insert(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new ResponseBase<Guid>(entity.Id);
        }
    }
}
