using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.InmueblesDocumentaciones;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Transacciones.InmueblesDocumentaciones.InmuebleDocumentacionCQRS.Queries
{
    public class GetInmueblesDocumentacionesQuery : IRequest<ResponseBase<List<InmuebleDocumentacionDto>>>
    {
    }

    public class GetInmueblesDocumentacionesQueryHandler : IRequestHandler<GetInmueblesDocumentacionesQuery, ResponseBase<List<InmuebleDocumentacionDto>>>
    {
        private readonly IRepository<InmuebleDocumentacion> _repository;
        private readonly IMapper _mapper;

        public GetInmueblesDocumentacionesQueryHandler(IRepository<InmuebleDocumentacion> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<InmuebleDocumentacionDto>>> Handle(GetInmueblesDocumentacionesQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<InmuebleDocumentacionDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<InmuebleDocumentacionDto>>(dto.ToList()));
        }
    }
}