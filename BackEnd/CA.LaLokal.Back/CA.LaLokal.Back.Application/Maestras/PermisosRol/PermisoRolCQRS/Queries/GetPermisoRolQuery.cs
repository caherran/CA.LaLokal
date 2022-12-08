using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.PermisosRol;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.PermisosRol.PermisoRolCQRS.Queries
{
    public class GetPermisoRolQuery : IRequest<ResponseBase<PermisoRolDto>>
    {
        public int Id { get; set; }
    }

    public class GetPermisoRolQueryHandler : IRequestHandler<GetPermisoRolQuery, ResponseBase<PermisoRolDto>>
    {
        private readonly IRepository<PermisoRol> _repository;
        private readonly IMapper _mapper;

        public GetPermisoRolQueryHandler(IRepository<PermisoRol> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<PermisoRolDto>> Handle(GetPermisoRolQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("PermisoRol", request.Id);
            }

            var dto = _mapper.Map<PermisoRolDto>(entity);

            return Task.FromResult(new ResponseBase<PermisoRolDto>(dto));
        }
    }
}