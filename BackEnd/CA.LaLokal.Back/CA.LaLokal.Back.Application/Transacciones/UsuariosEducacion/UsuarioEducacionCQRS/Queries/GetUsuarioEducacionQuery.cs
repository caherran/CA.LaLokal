using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosEducacion;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosEducacion.UsuarioEducacionCQRS.Queries
{
    public class GetUsuarioEducacionQuery : IRequest<ResponseBase<UsuarioEducacionDto>>
    {
        public Guid Id { get; set; }
    }

    public class GetUsuarioEducacionQueryHandler : IRequestHandler<GetUsuarioEducacionQuery, ResponseBase<UsuarioEducacionDto>>
    {
        private readonly IRepository<UsuarioEducacion> _repository;
        private readonly IMapper _mapper;

        public GetUsuarioEducacionQueryHandler(IRepository<UsuarioEducacion> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<UsuarioEducacionDto>> Handle(GetUsuarioEducacionQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("UsuarioEducacion", request.Id);
            }

            var dto = _mapper.Map<UsuarioEducacionDto>(entity);

            return Task.FromResult(new ResponseBase<UsuarioEducacionDto>(dto));
        }
    }
}