using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.Alcobas;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.Alcobas.AlcobaCQRS.Queries
{
    public class GetAlcobaQuery : IRequest<ResponseBase<AlcobaDto>>
    {
        public int Id { get; set; }
    }

    public class GetAlcobaQueryHandler : IRequestHandler<GetAlcobaQuery, ResponseBase<AlcobaDto>>
    {
        private readonly IRepository<Alcoba> _repository;
        private readonly IMapper _mapper;

        public GetAlcobaQueryHandler(IRepository<Alcoba> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<AlcobaDto>> Handle(GetAlcobaQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("Alcoba", request.Id);
            }

            var dto = _mapper.Map<AlcobaDto>(entity);

            return Task.FromResult(new ResponseBase<AlcobaDto>(dto));
        }
    }
}