using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.PermisosRol;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.PermisosRol.PermisoRolCQRS.Queries
{
    public class GetPermisosRolQuery : IRequest<ResponseBase<List<PermisoRolDto>>>
    {
    }

    public class GetPermisosRolQueryHandler : IRequestHandler<GetPermisosRolQuery, ResponseBase<List<PermisoRolDto>>>
    {
        private readonly IRepository<PermisoRol> _repository;
        private readonly IMapper _mapper;

        public GetPermisosRolQueryHandler(IRepository<PermisoRol> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<PermisoRolDto>>> Handle(GetPermisosRolQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<PermisoRolDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<PermisoRolDto>>(dto.ToList()));
        }
    }
}