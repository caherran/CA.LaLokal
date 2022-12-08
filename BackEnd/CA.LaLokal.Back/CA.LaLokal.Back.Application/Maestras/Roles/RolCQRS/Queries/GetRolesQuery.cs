using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.Roles;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.Roles.RolCQRS.Queries
{
    public class GetRolesQuery : IRequest<ResponseBase<List<RolDto>>>
    {
    }

    public class GetRolesQueryHandler : IRequestHandler<GetRolesQuery, ResponseBase<List<RolDto>>>
    {
        private readonly IRepository<Rol> _repository;
        private readonly IMapper _mapper;

        public GetRolesQueryHandler(IRepository<Rol> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<RolDto>>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<RolDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<RolDto>>(dto.ToList()));
        }
    }
}