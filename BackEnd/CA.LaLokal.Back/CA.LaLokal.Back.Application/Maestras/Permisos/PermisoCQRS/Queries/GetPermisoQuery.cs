using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.Permisos;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.Permisos.PermisoCQRS.Queries
{
    public class GetPermisoQuery : IRequest<ResponseBase<PermisoDto>>
    {
        public int Id { get; set; }
    }

    public class GetPermisoQueryHandler : IRequestHandler<GetPermisoQuery, ResponseBase<PermisoDto>>
    {
        private readonly IRepository<Permiso> _repository;
        private readonly IMapper _mapper;

        public GetPermisoQueryHandler(IRepository<Permiso> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<PermisoDto>> Handle(GetPermisoQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("Permiso", request.Id);
            }

            var dto = _mapper.Map<PermisoDto>(entity);

            return Task.FromResult(new ResponseBase<PermisoDto>(dto));
        }
    }
}