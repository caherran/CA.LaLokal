using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.InmueblesMultimedia;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Transacciones.InmueblesMultimedia.InmuebleMultimediaCQRS.Queries
{
    public class GetInmueblesMultimediaQuery : IRequest<ResponseBase<List<InmuebleMultimediaDto>>>
    {
    }

    public class GetInmueblesMultimediaQueryHandler : IRequestHandler<GetInmueblesMultimediaQuery, ResponseBase<List<InmuebleMultimediaDto>>>
    {
        private readonly IRepository<InmuebleMultimedia> _repository;
        private readonly IMapper _mapper;

        public GetInmueblesMultimediaQueryHandler(IRepository<InmuebleMultimedia> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<InmuebleMultimediaDto>>> Handle(GetInmueblesMultimediaQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<InmuebleMultimediaDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<InmuebleMultimediaDto>>(dto.ToList()));
        }
    }
}