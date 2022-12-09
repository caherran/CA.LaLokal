using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosEducacion;
using CA.GuidGenerator;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosEducacion.UsuarioEducacionCQRS.Commands.Create
{
    public class CreateUsuarioEducacionCommand : IRequest<ResponseBase<Guid>>, IMapFrom<UsuarioEducacion>
    {
        public Guid UsuarioId { get; set; }
public string Titulo { get; set; }
public string InstitucionUniversidad { get; set; }
public string Direccion { get; set; }
public bool EstudiaActualmente { get; set; }
public DateTime FechaInicio { get; set; }
public DateTime FechaFinalizacion { get; set; }

    }

    public class CreateUsuarioEducacionCommandHandler : IRequestHandler<CreateUsuarioEducacionCommand, ResponseBase<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<UsuarioEducacion> _repository;
        private readonly IMapper _mapper;

        public CreateUsuarioEducacionCommandHandler(IUnitOfWork unitOfWork, IRepository<UsuarioEducacion> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<Guid>> Handle(CreateUsuarioEducacionCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<UsuarioEducacion>(request);
            entity.Id = SequentialGuid.Create();
            _repository.Insert(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new ResponseBase<Guid>(entity.Id);
        }
    }
}
