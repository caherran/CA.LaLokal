using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.Portales;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.Portales.PortalCQRS.Queries
{
    public class GetPortalQuery : IRequest<ResponseBase<PortalDto>>
    {
        public int Id { get; set; }
    }

    public class GetPortalQueryHandler : IRequestHandler<GetPortalQuery, ResponseBase<PortalDto>>
    {
        private readonly IRepository<Portal> _repository;
        private readonly IMapper _mapper;

        public GetPortalQueryHandler(IRepository<Portal> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<PortalDto>> Handle(GetPortalQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("Portal", request.Id);
            }

            var dto = _mapper.Map<PortalDto>(entity);

            return Task.FromResult(new ResponseBase<PortalDto>(dto));
        }
    }
}