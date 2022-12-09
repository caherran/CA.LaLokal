using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.InmueblesMultimedia;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Transacciones.InmueblesMultimedia.InmuebleMultimediaCQRS.Queries
{
    public class GetInmuebleMultimediaQuery : IRequest<ResponseBase<InmuebleMultimediaDto>>
    {
        public Guid Id { get; set; }
    }

    public class GetInmuebleMultimediaQueryHandler : IRequestHandler<GetInmuebleMultimediaQuery, ResponseBase<InmuebleMultimediaDto>>
    {
        private readonly IRepository<InmuebleMultimedia> _repository;
        private readonly IMapper _mapper;

        public GetInmuebleMultimediaQueryHandler(IRepository<InmuebleMultimedia> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<InmuebleMultimediaDto>> Handle(GetInmuebleMultimediaQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("InmuebleMultimedia", request.Id);
            }

            var dto = _mapper.Map<InmuebleMultimediaDto>(entity);

            return Task.FromResult(new ResponseBase<InmuebleMultimediaDto>(dto));
        }
    }
}