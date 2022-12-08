using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.Funcionalidades;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.Funcionalidades.FuncionalidadCQRS.Queries
{
    public class GetFuncionalidadQuery : IRequest<ResponseBase<FuncionalidadDto>>
    {
        public int Id { get; set; }
    }

    public class GetFuncionalidadQueryHandler : IRequestHandler<GetFuncionalidadQuery, ResponseBase<FuncionalidadDto>>
    {
        private readonly IRepository<Funcionalidad> _repository;
        private readonly IMapper _mapper;

        public GetFuncionalidadQueryHandler(IRepository<Funcionalidad> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<FuncionalidadDto>> Handle(GetFuncionalidadQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("Funcionalidad", request.Id);
            }

            var dto = _mapper.Map<FuncionalidadDto>(entity);

            return Task.FromResult(new ResponseBase<FuncionalidadDto>(dto));
        }
    }
}