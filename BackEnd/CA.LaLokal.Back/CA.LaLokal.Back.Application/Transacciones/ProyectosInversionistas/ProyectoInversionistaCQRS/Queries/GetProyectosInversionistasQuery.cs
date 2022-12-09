using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.ProyectosInversionistas;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Transacciones.ProyectosInversionistas.ProyectoInversionistaCQRS.Queries
{
    public class GetProyectosInversionistasQuery : IRequest<ResponseBase<List<ProyectoInversionistaDto>>>
    {
    }

    public class GetProyectosInversionistasQueryHandler : IRequestHandler<GetProyectosInversionistasQuery, ResponseBase<List<ProyectoInversionistaDto>>>
    {
        private readonly IRepository<ProyectoInversionista> _repository;
        private readonly IMapper _mapper;

        public GetProyectosInversionistasQueryHandler(IRepository<ProyectoInversionista> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<ProyectoInversionistaDto>>> Handle(GetProyectosInversionistasQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<ProyectoInversionistaDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<ProyectoInversionistaDto>>(dto.ToList()));
        }
    }
}