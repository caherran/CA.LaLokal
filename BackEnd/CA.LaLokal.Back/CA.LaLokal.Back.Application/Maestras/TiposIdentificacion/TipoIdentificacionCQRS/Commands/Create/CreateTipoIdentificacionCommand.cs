using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.TiposIdentificacion;
using CA.GuidGenerator;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.TiposIdentificacion.TipoIdentificacionCQRS.Commands.Create
{
    public class CreateTipoIdentificacionCommand : IRequest<ResponseBase<int>>, IMapFrom<TipoIdentificacion>
    {
        public string Descripcion { get; set; }

    }

    public class CreateTipoIdentificacionCommandHandler : IRequestHandler<CreateTipoIdentificacionCommand, ResponseBase<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TipoIdentificacion> _repository;
        private readonly IMapper _mapper;

        public CreateTipoIdentificacionCommandHandler(IUnitOfWork unitOfWork, IRepository<TipoIdentificacion> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<int>> Handle(CreateTipoIdentificacionCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<TipoIdentificacion>(request);
            //entity.Id = SequentialGuid.Create();
            _repository.Insert(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new ResponseBase<int>(entity.Id);
        }
    }
}
