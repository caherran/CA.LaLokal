using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.Garajes;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.Garajes.GarajeCQRS.Queries
{
    public class GetGarajeQuery : IRequest<ResponseBase<GarajeDto>>
    {
        public int Id { get; set; }
    }

    public class GetGarajeQueryHandler : IRequestHandler<GetGarajeQuery, ResponseBase<GarajeDto>>
    {
        private readonly IRepository<Garaje> _repository;
        private readonly IMapper _mapper;

        public GetGarajeQueryHandler(IRepository<Garaje> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<GarajeDto>> Handle(GetGarajeQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("Garaje", request.Id);
            }

            var dto = _mapper.Map<GarajeDto>(entity);

            return Task.FromResult(new ResponseBase<GarajeDto>(dto));
        }
    }
}