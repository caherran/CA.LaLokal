using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.Permisos;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.Permisos.PermisoCQRS.Queries
{
    public class GetPermisosQuery : IRequest<ResponseBase<List<PermisoDto>>>
    {
    }

    public class GetPermisosQueryHandler : IRequestHandler<GetPermisosQuery, ResponseBase<List<PermisoDto>>>
    {
        private readonly IRepository<Permiso> _repository;
        private readonly IMapper _mapper;

        public GetPermisosQueryHandler(IRepository<Permiso> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<PermisoDto>>> Handle(GetPermisosQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<PermisoDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<PermisoDto>>(dto.ToList()));
        }
    }
}