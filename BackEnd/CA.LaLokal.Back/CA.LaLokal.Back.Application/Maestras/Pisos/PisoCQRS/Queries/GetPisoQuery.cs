using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.Pisos;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.Pisos.PisoCQRS.Queries
{
    public class GetPisoQuery : IRequest<ResponseBase<PisoDto>>
    {
        public int Id { get; set; }
    }

    public class GetPisoQueryHandler : IRequestHandler<GetPisoQuery, ResponseBase<PisoDto>>
    {
        private readonly IRepository<Piso> _repository;
        private readonly IMapper _mapper;

        public GetPisoQueryHandler(IRepository<Piso> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<PisoDto>> Handle(GetPisoQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("Piso", request.Id);
            }

            var dto = _mapper.Map<PisoDto>(entity);

            return Task.FromResult(new ResponseBase<PisoDto>(dto));
        }
    }
}