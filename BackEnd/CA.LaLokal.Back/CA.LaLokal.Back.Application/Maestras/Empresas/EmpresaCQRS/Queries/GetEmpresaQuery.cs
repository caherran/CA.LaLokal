using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.Empresas;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.Empresas.EmpresaCQRS.Queries
{
    public class GetEmpresaQuery : IRequest<ResponseBase<EmpresaDto>>
    {
        public int Id { get; set; }
    }

    public class GetEmpresaQueryHandler : IRequestHandler<GetEmpresaQuery, ResponseBase<EmpresaDto>>
    {
        private readonly IRepository<Empresa> _repository;
        private readonly IMapper _mapper;

        public GetEmpresaQueryHandler(IRepository<Empresa> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<EmpresaDto>> Handle(GetEmpresaQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("Empresa", request.Id);
            }

            var dto = _mapper.Map<EmpresaDto>(entity);

            return Task.FromResult(new ResponseBase<EmpresaDto>(dto));
        }
    }
}