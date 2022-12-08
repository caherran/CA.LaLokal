using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.Ciudades;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.Ciudades.CiudadCQRS.Queries
{
    public class GetCiudadQuery : IRequest<ResponseBase<CiudadDto>>
    {
        public int Id { get; set; }
    }

    public class GetCiudadQueryHandler : IRequestHandler<GetCiudadQuery, ResponseBase<CiudadDto>>
    {
        private readonly IRepository<Ciudad> _repository;
        private readonly IMapper _mapper;

        public GetCiudadQueryHandler(IRepository<Ciudad> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<CiudadDto>> Handle(GetCiudadQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("Ciudad", request.Id);
            }

            var dto = _mapper.Map<CiudadDto>(entity);

            return Task.FromResult(new ResponseBase<CiudadDto>(dto));
        }
    }
}