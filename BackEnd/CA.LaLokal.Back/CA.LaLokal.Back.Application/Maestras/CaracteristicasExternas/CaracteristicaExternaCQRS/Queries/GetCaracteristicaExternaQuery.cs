using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.CaracteristicasExternas;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.CaracteristicasExternas.CaracteristicaExternaCQRS.Queries
{
    public class GetCaracteristicaExternaQuery : IRequest<ResponseBase<CaracteristicaExternaDto>>
    {
        public int Id { get; set; }
    }

    public class GetCaracteristicaExternaQueryHandler : IRequestHandler<GetCaracteristicaExternaQuery, ResponseBase<CaracteristicaExternaDto>>
    {
        private readonly IRepository<CaracteristicaExterna> _repository;
        private readonly IMapper _mapper;

        public GetCaracteristicaExternaQueryHandler(IRepository<CaracteristicaExterna> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<CaracteristicaExternaDto>> Handle(GetCaracteristicaExternaQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("CaracteristicaExterna", request.Id);
            }

            var dto = _mapper.Map<CaracteristicaExternaDto>(entity);

            return Task.FromResult(new ResponseBase<CaracteristicaExternaDto>(dto));
        }
    }
}