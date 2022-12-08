using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.CaracteristicasInternas;
using CA.GuidGenerator;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.CaracteristicasInternas.CaracteristicaInternaCQRS.Commands.Create
{
    public class CreateCaracteristicaInternaCommand : IRequest<ResponseBase<int>>, IMapFrom<CaracteristicaInterna>
    {
        public string Descripcion { get; set; }

    }

    public class CreateCaracteristicaInternaCommandHandler : IRequestHandler<CreateCaracteristicaInternaCommand, ResponseBase<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<CaracteristicaInterna> _repository;
        private readonly IMapper _mapper;

        public CreateCaracteristicaInternaCommandHandler(IUnitOfWork unitOfWork, IRepository<CaracteristicaInterna> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<int>> Handle(CreateCaracteristicaInternaCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<CaracteristicaInterna>(request);
            //entity.Id = SequentialGuid.Create();
            _repository.Insert(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new ResponseBase<int>(entity.Id);
        }
    }
}
