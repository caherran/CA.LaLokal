using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.EstadosCartera;
using CA.GuidGenerator;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.EstadosCartera.EstadoCarteraCQRS.Commands.Create
{
    public class CreateEstadoCarteraCommand : IRequest<ResponseBase<int>>, IMapFrom<EstadoCartera>
    {
        public string Descripcion { get; set; }

    }

    public class CreateEstadoCarteraCommandHandler : IRequestHandler<CreateEstadoCarteraCommand, ResponseBase<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<EstadoCartera> _repository;
        private readonly IMapper _mapper;

        public CreateEstadoCarteraCommandHandler(IUnitOfWork unitOfWork, IRepository<EstadoCartera> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<int>> Handle(CreateEstadoCarteraCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<EstadoCartera>(request);
            //entity.Id = SequentialGuid.Create();
            _repository.Insert(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new ResponseBase<int>(entity.Id);
        }
    }
}
