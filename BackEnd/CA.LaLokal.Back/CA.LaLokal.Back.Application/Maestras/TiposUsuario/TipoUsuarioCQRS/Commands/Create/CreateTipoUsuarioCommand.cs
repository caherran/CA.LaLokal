using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.TiposUsuario;
using CA.GuidGenerator;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.TiposUsuario.TipoUsuarioCQRS.Commands.Create
{
    public class CreateTipoUsuarioCommand : IRequest<ResponseBase<int>>, IMapFrom<TipoUsuario>
    {
        public string Descripcion { get; set; }

    }

    public class CreateTipoUsuarioCommandHandler : IRequestHandler<CreateTipoUsuarioCommand, ResponseBase<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TipoUsuario> _repository;
        private readonly IMapper _mapper;

        public CreateTipoUsuarioCommandHandler(IUnitOfWork unitOfWork, IRepository<TipoUsuario> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<int>> Handle(CreateTipoUsuarioCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<TipoUsuario>(request);
            //entity.Id = SequentialGuid.Create();
            _repository.Insert(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new ResponseBase<int>(entity.Id);
        }
    }
}
