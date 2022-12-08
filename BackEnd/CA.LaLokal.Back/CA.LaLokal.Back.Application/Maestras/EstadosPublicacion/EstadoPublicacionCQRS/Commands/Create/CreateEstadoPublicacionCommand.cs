using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.EstadosPublicacion;
using CA.GuidGenerator;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.EstadosPublicacion.EstadoPublicacionCQRS.Commands.Create
{
    public class CreateEstadoPublicacionCommand : IRequest<ResponseBase<int>>, IMapFrom<EstadoPublicacion>
    {
        public string Descripcion { get; set; }

    }

    public class CreateEstadoPublicacionCommandHandler : IRequestHandler<CreateEstadoPublicacionCommand, ResponseBase<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<EstadoPublicacion> _repository;
        private readonly IMapper _mapper;

        public CreateEstadoPublicacionCommandHandler(IUnitOfWork unitOfWork, IRepository<EstadoPublicacion> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<int>> Handle(CreateEstadoPublicacionCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<EstadoPublicacion>(request);
            //entity.Id = SequentialGuid.Create();
            _repository.Insert(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new ResponseBase<int>(entity.Id);
        }
    }
}
