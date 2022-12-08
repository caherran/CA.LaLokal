using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.Tiempos;
using CA.GuidGenerator;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.Tiempos.TiempoCQRS.Commands.Create
{
    public class CreateTiempoCommand : IRequest<ResponseBase<int>>, IMapFrom<Tiempo>
    {
        public string Descripcion { get; set; }

    }

    public class CreateTiempoCommandHandler : IRequestHandler<CreateTiempoCommand, ResponseBase<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Tiempo> _repository;
        private readonly IMapper _mapper;

        public CreateTiempoCommandHandler(IUnitOfWork unitOfWork, IRepository<Tiempo> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<int>> Handle(CreateTiempoCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Tiempo>(request);
            //entity.Id = SequentialGuid.Create();
            _repository.Insert(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new ResponseBase<int>(entity.Id);
        }
    }
}
