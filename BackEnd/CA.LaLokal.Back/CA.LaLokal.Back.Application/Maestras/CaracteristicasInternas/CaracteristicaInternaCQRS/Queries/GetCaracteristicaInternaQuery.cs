using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.CaracteristicasInternas;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.CaracteristicasInternas.CaracteristicaInternaCQRS.Queries
{
    public class GetCaracteristicaInternaQuery : IRequest<ResponseBase<CaracteristicaInternaDto>>
    {
        public int Id { get; set; }
    }

    public class GetCaracteristicaInternaQueryHandler : IRequestHandler<GetCaracteristicaInternaQuery, ResponseBase<CaracteristicaInternaDto>>
    {
        private readonly IRepository<CaracteristicaInterna> _repository;
        private readonly IMapper _mapper;

        public GetCaracteristicaInternaQueryHandler(IRepository<CaracteristicaInterna> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<CaracteristicaInternaDto>> Handle(GetCaracteristicaInternaQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("CaracteristicaInterna", request.Id);
            }

            var dto = _mapper.Map<CaracteristicaInternaDto>(entity);

            return Task.FromResult(new ResponseBase<CaracteristicaInternaDto>(dto));
        }
    }
}