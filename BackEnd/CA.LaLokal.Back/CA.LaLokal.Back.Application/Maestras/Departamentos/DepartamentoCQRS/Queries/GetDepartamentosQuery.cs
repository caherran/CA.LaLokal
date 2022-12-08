using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.Departamentos;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.Departamentos.DepartamentoCQRS.Queries
{
    public class GetDepartamentosQuery : IRequest<ResponseBase<List<DepartamentoDto>>>
    {
    }

    public class GetDepartamentosQueryHandler : IRequestHandler<GetDepartamentosQuery, ResponseBase<List<DepartamentoDto>>>
    {
        private readonly IRepository<Departamento> _repository;
        private readonly IMapper _mapper;

        public GetDepartamentosQueryHandler(IRepository<Departamento> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<DepartamentoDto>>> Handle(GetDepartamentosQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<DepartamentoDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<DepartamentoDto>>(dto.ToList()));
        }
    }
}