using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.TiposInmueble;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.TiposInmueble.TipoInmuebleCQRS.Queries
{
    public class GetTipoInmuebleQuery : IRequest<ResponseBase<TipoInmuebleDto>>
    {
        public int Id { get; set; }
    }

    public class GetTipoInmuebleQueryHandler : IRequestHandler<GetTipoInmuebleQuery, ResponseBase<TipoInmuebleDto>>
    {
        private readonly IRepository<TipoInmueble> _repository;
        private readonly IMapper _mapper;

        public GetTipoInmuebleQueryHandler(IRepository<TipoInmueble> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<TipoInmuebleDto>> Handle(GetTipoInmuebleQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("TipoInmueble", request.Id);
            }

            var dto = _mapper.Map<TipoInmuebleDto>(entity);

            return Task.FromResult(new ResponseBase<TipoInmuebleDto>(dto));
        }
    }
}