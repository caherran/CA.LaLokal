using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosExperienciasLaborales;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosExperienciasLaborales.UsuarioExperienciaLaboralCQRS.Commands.Update
{
    public class UpdateUsuarioExperienciaLaboralCommand : IRequest<ResponseBase<bool>>, IMapFrom<UsuarioExperienciaLaboral>
    {
        public Guid Id { get; set; }
public Guid UsuarioId { get; set; }
public string NombreEmpresa { get; set; }
public string Cargo { get; set; }
public string Direccion { get; set; }
public bool TrabajaActualmente { get; set; }
public DateTime FechaInicio { get; set; }
public DateTime FechaFinalizacion { get; set; }

    }

    public class UpdateUsuarioExperienciaLaboralCommandHandler : IRequestHandler<UpdateUsuarioExperienciaLaboralCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<UsuarioExperienciaLaboral> _repository;
        private readonly IMapper _mapper;

        public UpdateUsuarioExperienciaLaboralCommandHandler(IUnitOfWork unitOfWork, IRepository<UsuarioExperienciaLaboral> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<bool>> Handle(UpdateUsuarioExperienciaLaboralCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("UsuarioExperienciaLaboral", request.Id);
            }

            _mapper.Map(request, entity);

            _repository.Update(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
