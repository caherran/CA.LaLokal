using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.TiposIdentificacion;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.TiposIdentificacion.TipoIdentificacionCQRS.Queries
{
    public class GetTipoIdentificacionQuery : IRequest<ResponseBase<TipoIdentificacionDto>>
    {
        public int Id { get; set; }
    }

    public class GetTipoIdentificacionQueryHandler : IRequestHandler<GetTipoIdentificacionQuery, ResponseBase<TipoIdentificacionDto>>
    {
        private readonly IRepository<TipoIdentificacion> _repository;
        private readonly IMapper _mapper;

        public GetTipoIdentificacionQueryHandler(IRepository<TipoIdentificacion> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<TipoIdentificacionDto>> Handle(GetTipoIdentificacionQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("TipoIdentificacion", request.Id);
            }

            var dto = _mapper.Map<TipoIdentificacionDto>(entity);

            return Task.FromResult(new ResponseBase<TipoIdentificacionDto>(dto));
        }
    }
}