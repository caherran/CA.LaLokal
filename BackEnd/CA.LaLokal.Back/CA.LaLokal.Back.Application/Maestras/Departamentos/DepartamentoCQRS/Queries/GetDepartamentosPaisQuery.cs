using AutoMapper;
using CA.LaLokal.Back.Application.Maestras.Paises.PaisCQRS.Queries;
using CA.LaLokal.Back.Domain.Maestras.Departamentos;
using CA.LaLokal.Back.Domain.Maestras.Paises;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CA.LaLokal.Back.Application.Maestras.Departamentos.DepartamentoCQRS.Queries
{
    public class GetDepartamentosPaisQuery : IRequest<ResponseBase<List<DepartamentoDto>>>
    {
        public int PaisId { get; set; }
    }

    public class GetDepartamentosPaisQueryHandler : IRequestHandler<GetDepartamentosPaisQuery, ResponseBase<List<DepartamentoDto>>>
    {
        private readonly IRepository<Departamento> _repository;
        private readonly IMapper _mapper;
        private readonly IRepository<Pais> _repositoryPais;

        public GetDepartamentosPaisQueryHandler(IRepository<Departamento> repository, IMapper mapper, IRepository<Pais> repositoryPais)
        {
            _repository = repository;
            _mapper = mapper;
            _repositoryPais = repositoryPais;
        }

        public Task<ResponseBase<List<DepartamentoDto>>> Handle(GetDepartamentosPaisQuery request, CancellationToken cancellationToken)
        {
            var query = from departamento in _repository.TableNoTracking
                        join pais in _repositoryPais.TableNoTracking on departamento.PaisId equals pais.Id
                        where pais.Id == request.PaisId
                        select new DepartamentoDto()
                        {
                            Id = departamento.Id,
                            Codigo = departamento.Codigo,
                            Nombre = departamento.Nombre,
                            Pais = new PaisDto()
                            {
                                Id = pais.Id,
                                Codigo = pais.Codigo,
                                Nombre = pais.Nombre
                            }
                        };

            return Task.FromResult(new ResponseBase<List<DepartamentoDto>>(query.ToList()));
        }
    }
}