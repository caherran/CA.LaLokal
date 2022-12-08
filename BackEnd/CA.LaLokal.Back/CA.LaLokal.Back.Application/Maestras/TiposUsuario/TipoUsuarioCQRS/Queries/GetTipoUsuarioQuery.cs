using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.TiposUsuario;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.TiposUsuario.TipoUsuarioCQRS.Queries
{
    public class GetTipoUsuarioQuery : IRequest<ResponseBase<TipoUsuarioDto>>
    {
        public int Id { get; set; }
    }

    public class GetTipoUsuarioQueryHandler : IRequestHandler<GetTipoUsuarioQuery, ResponseBase<TipoUsuarioDto>>
    {
        private readonly IRepository<TipoUsuario> _repository;
        private readonly IMapper _mapper;

        public GetTipoUsuarioQueryHandler(IRepository<TipoUsuario> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<TipoUsuarioDto>> Handle(GetTipoUsuarioQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("TipoUsuario", request.Id);
            }

            var dto = _mapper.Map<TipoUsuarioDto>(entity);

            return Task.FromResult(new ResponseBase<TipoUsuarioDto>(dto));
        }
    }
}