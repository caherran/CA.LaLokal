using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosMultimedia;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosMultimedia.UsuarioMultimediaCQRS.Queries
{
    public class GetUsuarioMultimediaQuery : IRequest<ResponseBase<UsuarioMultimediaDto>>
    {
        public Guid Id { get; set; }
    }

    public class GetUsuarioMultimediaQueryHandler : IRequestHandler<GetUsuarioMultimediaQuery, ResponseBase<UsuarioMultimediaDto>>
    {
        private readonly IRepository<UsuarioMultimedia> _repository;
        private readonly IMapper _mapper;

        public GetUsuarioMultimediaQueryHandler(IRepository<UsuarioMultimedia> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<UsuarioMultimediaDto>> Handle(GetUsuarioMultimediaQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("UsuarioMultimedia", request.Id);
            }

            var dto = _mapper.Map<UsuarioMultimediaDto>(entity);

            return Task.FromResult(new ResponseBase<UsuarioMultimediaDto>(dto));
        }
    }
}