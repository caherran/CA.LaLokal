using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.ZonasBarrios;
using CA.GuidGenerator;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.ZonasBarrios.ZonaBarrioCQRS.Commands.Create
{
    public class CreateZonaBarrioCommand : IRequest<ResponseBase<int>>, IMapFrom<ZonaBarrio>
    {
        public int CiudadId { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }

    }

    public class CreateZonaBarrioCommandHandler : IRequestHandler<CreateZonaBarrioCommand, ResponseBase<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<ZonaBarrio> _repository;
        private readonly IMapper _mapper;

        public CreateZonaBarrioCommandHandler(IUnitOfWork unitOfWork, IRepository<ZonaBarrio> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<int>> Handle(CreateZonaBarrioCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ZonaBarrio>(request);
            //entity.Id = SequentialGuid.Create();
            _repository.Insert(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new ResponseBase<int>(entity.Id);
        }
    }
}
