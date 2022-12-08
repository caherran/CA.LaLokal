using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.CaracteristicasExternas;
using CA.GuidGenerator;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.CaracteristicasExternas.CaracteristicaExternaCQRS.Commands.Create
{
    public class CreateCaracteristicaExternaCommand : IRequest<ResponseBase<int>>, IMapFrom<CaracteristicaExterna>
    {
        public string Descripcion { get; set; }

    }

    public class CreateCaracteristicaExternaCommandHandler : IRequestHandler<CreateCaracteristicaExternaCommand, ResponseBase<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<CaracteristicaExterna> _repository;
        private readonly IMapper _mapper;

        public CreateCaracteristicaExternaCommandHandler(IUnitOfWork unitOfWork, IRepository<CaracteristicaExterna> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<int>> Handle(CreateCaracteristicaExternaCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<CaracteristicaExterna>(request);
            //entity.Id = SequentialGuid.Create();
            _repository.Insert(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new ResponseBase<int>(entity.Id);
        }
    }
}
