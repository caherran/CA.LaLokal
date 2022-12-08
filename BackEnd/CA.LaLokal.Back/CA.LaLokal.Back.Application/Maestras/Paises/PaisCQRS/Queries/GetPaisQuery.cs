using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.Paises;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.Paises.PaisCQRS.Queries
{
    public class GetPaisQuery : IRequest<ResponseBase<PaisDto>>
    {
        public int Id { get; set; }
    }

    public class GetPaisQueryHandler : IRequestHandler<GetPaisQuery, ResponseBase<PaisDto>>
    {
        private readonly IRepository<Pais> _repository;
        private readonly IMapper _mapper;

        public GetPaisQueryHandler(IRepository<Pais> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<PaisDto>> Handle(GetPaisQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("Pais", request.Id);
            }

            var dto = _mapper.Map<PaisDto>(entity);

            return Task.FromResult(new ResponseBase<PaisDto>(dto));
        }
    }
}