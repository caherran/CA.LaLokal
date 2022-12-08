using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.Funcionalidades;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.Funcionalidades.FuncionalidadCQRS.Queries
{
    public class GetFuncionalidadesQuery : IRequest<ResponseBase<List<FuncionalidadDto>>>
    {
    }

    public class GetFuncionalidadesQueryHandler : IRequestHandler<GetFuncionalidadesQuery, ResponseBase<List<FuncionalidadDto>>>
    {
        private readonly IRepository<Funcionalidad> _repository;
        private readonly IMapper _mapper;

        public GetFuncionalidadesQueryHandler(IRepository<Funcionalidad> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<FuncionalidadDto>>> Handle(GetFuncionalidadesQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<FuncionalidadDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<FuncionalidadDto>>(dto.ToList()));
        }
    }
}