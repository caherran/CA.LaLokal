using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.EstadosProyecto;
using CA.GuidGenerator;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.EstadosProyecto.EstadoProyectoCQRS.Commands.Create
{
    public class CreateEstadoProyectoCommand : IRequest<ResponseBase<int>>, IMapFrom<EstadoProyecto>
    {
        public string Descripcion { get; set; }

    }

    public class CreateEstadoProyectoCommandHandler : IRequestHandler<CreateEstadoProyectoCommand, ResponseBase<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<EstadoProyecto> _repository;
        private readonly IMapper _mapper;

        public CreateEstadoProyectoCommandHandler(IUnitOfWork unitOfWork, IRepository<EstadoProyecto> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<int>> Handle(CreateEstadoProyectoCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<EstadoProyecto>(request);
            //entity.Id = SequentialGuid.Create();
            _repository.Insert(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new ResponseBase<int>(entity.Id);
        }
    }
}
