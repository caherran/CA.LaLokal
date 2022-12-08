using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.Empresas;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.Empresas.EmpresaCQRS.Queries
{
    public class GetEmpresasQuery : IRequest<ResponseBase<List<EmpresaDto>>>
    {
    }

    public class GetEmpresasQueryHandler : IRequestHandler<GetEmpresasQuery, ResponseBase<List<EmpresaDto>>>
    {
        private readonly IRepository<Empresa> _repository;
        private readonly IMapper _mapper;

        public GetEmpresasQueryHandler(IRepository<Empresa> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<EmpresaDto>>> Handle(GetEmpresasQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<EmpresaDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<EmpresaDto>>(dto.ToList()));
        }
    }
}