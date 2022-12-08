using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.Roles;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.Roles.RolCQRS.Queries
{
    public class GetRolQuery : IRequest<ResponseBase<RolDto>>
    {
        public int Id { get; set; }
    }

    public class GetRolQueryHandler : IRequestHandler<GetRolQuery, ResponseBase<RolDto>>
    {
        private readonly IRepository<Rol> _repository;
        private readonly IMapper _mapper;

        public GetRolQueryHandler(IRepository<Rol> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<RolDto>> Handle(GetRolQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("Rol", request.Id);
            }

            var dto = _mapper.Map<RolDto>(entity);

            return Task.FromResult(new ResponseBase<RolDto>(dto));
        }
    }
}