using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosEducacion;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosEducacion.UsuarioEducacionCQRS.Commands.Update
{
    public class UpdateUsuarioEducacionCommand : IRequest<ResponseBase<bool>>, IMapFrom<UsuarioEducacion>
    {
        public Guid Id { get; set; }
public Guid UsuarioId { get; set; }
public string Titulo { get; set; }
public string InstitucionUniversidad { get; set; }
public string Direccion { get; set; }
public bool EstudiaActualmente { get; set; }
public DateTime FechaInicio { get; set; }
public DateTime FechaFinalizacion { get; set; }

    }

    public class UpdateUsuarioEducacionCommandHandler : IRequestHandler<UpdateUsuarioEducacionCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<UsuarioEducacion> _repository;
        private readonly IMapper _mapper;

        public UpdateUsuarioEducacionCommandHandler(IUnitOfWork unitOfWork, IRepository<UsuarioEducacion> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<bool>> Handle(UpdateUsuarioEducacionCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("UsuarioEducacion", request.Id);
            }

            _mapper.Map(request, entity);

            _repository.Update(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
