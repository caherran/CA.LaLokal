using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.InmueblesMultimediaImagenes;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Transacciones.InmueblesMultimediaImagenes.InmuebleMultimediaImagenCQRS.Queries
{
    public class GetInmueblesMultimediaImagenesQuery : IRequest<ResponseBase<List<InmuebleMultimediaImagenDto>>>
    {
    }

    public class GetInmueblesMultimediaImagenesQueryHandler : IRequestHandler<GetInmueblesMultimediaImagenesQuery, ResponseBase<List<InmuebleMultimediaImagenDto>>>
    {
        private readonly IRepository<InmuebleMultimediaImagen> _repository;
        private readonly IMapper _mapper;

        public GetInmueblesMultimediaImagenesQueryHandler(IRepository<InmuebleMultimediaImagen> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<InmuebleMultimediaImagenDto>>> Handle(GetInmueblesMultimediaImagenesQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<InmuebleMultimediaImagenDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<InmuebleMultimediaImagenDto>>(dto.ToList()));
        }
    }
}