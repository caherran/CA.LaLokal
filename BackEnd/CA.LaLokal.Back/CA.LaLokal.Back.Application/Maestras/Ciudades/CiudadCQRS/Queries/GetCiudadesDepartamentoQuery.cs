using AutoMapper;
using CA.LaLokal.Back.Application.Maestras.Departamentos.DepartamentoCQRS.Queries;
using CA.LaLokal.Back.Domain.Maestras.Ciudades;
using CA.LaLokal.Back.Domain.Maestras.Departamentos;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CA.LaLokal.Back.Application.Maestras.Ciudades.CiudadCQRS.Queries
{
    public class GetCiudadesDepartamentoQuery : IRequest<ResponseBase<List<CiudadDto>>>
    {
        public int DepartamentoId { get; set; }
    }

    public class GetCiudadesDepartamentoHandler : IRequestHandler<GetCiudadesDepartamentoQuery, ResponseBase<List<CiudadDto>>>
    {
        private readonly IRepository<Ciudad> _repository;
        private readonly IMapper _mapper;
        private readonly IRepository<Departamento> _repositoryDepartamento;

        public GetCiudadesDepartamentoHandler(IRepository<Ciudad> repository, IMapper mapper, IRepository<Departamento> repositoryDepartamento)
        {
            _repository = repository;
            _mapper = mapper;
            _repositoryDepartamento = repositoryDepartamento;
        }

        public Task<ResponseBase<List<CiudadDto>>> Handle(GetCiudadesDepartamentoQuery request, CancellationToken cancellationToken)
        {
            var query = from ciudad in _repository.TableNoTracking
                        join departamento in _repositoryDepartamento.TableNoTracking on ciudad.DepartamentoId equals departamento.Id
                        where departamento.Id == request.DepartamentoId
                        select new CiudadDto()
                        {
                            Id = ciudad.Id,
                            Codigo = ciudad.Codigo,
                            Nombre = ciudad.Nombre,
                            Departamento = new DepartamentoDto()
                            {
                                Id = departamento.Id,
                                Codigo = departamento.Codigo,
                                Nombre = departamento.Nombre
                            }
                        };

            return Task.FromResult(new ResponseBase<List<CiudadDto>>(query.ToList()));
        }
    }
}