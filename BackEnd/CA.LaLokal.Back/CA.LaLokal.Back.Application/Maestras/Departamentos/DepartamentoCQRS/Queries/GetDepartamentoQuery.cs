using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.Departamentos;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.Departamentos.DepartamentoCQRS.Queries
{
    public class GetDepartamentoQuery : IRequest<ResponseBase<DepartamentoDto>>
    {
        public int Id { get; set; }
    }

    public class GetDepartamentoQueryHandler : IRequestHandler<GetDepartamentoQuery, ResponseBase<DepartamentoDto>>
    {
        private readonly IRepository<Departamento> _repository;
        private readonly IMapper _mapper;

        public GetDepartamentoQueryHandler(IRepository<Departamento> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<DepartamentoDto>> Handle(GetDepartamentoQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("Departamento", request.Id);
            }

            var dto = _mapper.Map<DepartamentoDto>(entity);

            return Task.FromResult(new ResponseBase<DepartamentoDto>(dto));
        }
    }
}