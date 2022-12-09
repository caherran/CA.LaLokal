using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.InmueblesMultimediaImagenes;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Transacciones.InmueblesMultimediaImagenes.InmuebleMultimediaImagenCQRS.Queries
{
    public class GetInmuebleMultimediaImagenQuery : IRequest<ResponseBase<InmuebleMultimediaImagenDto>>
    {
        public Guid Id { get; set; }
    }

    public class GetInmuebleMultimediaImagenQueryHandler : IRequestHandler<GetInmuebleMultimediaImagenQuery, ResponseBase<InmuebleMultimediaImagenDto>>
    {
        private readonly IRepository<InmuebleMultimediaImagen> _repository;
        private readonly IMapper _mapper;

        public GetInmuebleMultimediaImagenQueryHandler(IRepository<InmuebleMultimediaImagen> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<InmuebleMultimediaImagenDto>> Handle(GetInmuebleMultimediaImagenQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("InmuebleMultimediaImagen", request.Id);
            }

            var dto = _mapper.Map<InmuebleMultimediaImagenDto>(entity);

            return Task.FromResult(new ResponseBase<InmuebleMultimediaImagenDto>(dto));
        }
    }
}