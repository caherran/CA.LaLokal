using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.ZonasGeografias;
using CA.GuidGenerator;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.ZonasGeografias.ZonaGeograficaCQRS.Commands.Create
{
    public class CreateZonaGeograficaCommand : IRequest<ResponseBase<int>>, IMapFrom<ZonaGeografica>
    {
        public int ZonaBarrioId { get; set; }

    }

    public class CreateZonaGeograficaCommandHandler : IRequestHandler<CreateZonaGeograficaCommand, ResponseBase<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<ZonaGeografica> _repository;
        private readonly IMapper _mapper;

        public CreateZonaGeograficaCommandHandler(IUnitOfWork unitOfWork, IRepository<ZonaGeografica> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<int>> Handle(CreateZonaGeograficaCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ZonaGeografica>(request);
            //entity.Id = SequentialGuid.Create();
            _repository.Insert(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new ResponseBase<int>(entity.Id);
        }
    }
}
