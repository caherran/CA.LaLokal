using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosMultimedia;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosMultimedia.UsuarioMultimediaCQRS.Queries
{
    public class GetUsuariosMultimediaQuery : IRequest<ResponseBase<List<UsuarioMultimediaDto>>>
    {
    }

    public class GetUsuariosMultimediaQueryHandler : IRequestHandler<GetUsuariosMultimediaQuery, ResponseBase<List<UsuarioMultimediaDto>>>
    {
        private readonly IRepository<UsuarioMultimedia> _repository;
        private readonly IMapper _mapper;

        public GetUsuariosMultimediaQueryHandler(IRepository<UsuarioMultimedia> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<UsuarioMultimediaDto>>> Handle(GetUsuariosMultimediaQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<UsuarioMultimediaDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<UsuarioMultimediaDto>>(dto.ToList()));
        }
    }
}