using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.InmueblesUsuarios;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Transacciones.InmueblesUsuarios.InmuebleUsuarioCQRS.Commands.Update
{
    public class UpdateInmuebleUsuarioCommand : IRequest<ResponseBase<bool>>, IMapFrom<InmuebleUsuario>
    {
        public Guid Id { get; set; }
public Guid InmuebleId { get; set; }
public Guid UsuarioId { get; set; }
public int TipoClienteId { get; set; }

    }

    public class UpdateInmuebleUsuarioCommandHandler : IRequestHandler<UpdateInmuebleUsuarioCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<InmuebleUsuario> _repository;
        private readonly IMapper _mapper;

        public UpdateInmuebleUsuarioCommandHandler(IUnitOfWork unitOfWork, IRepository<InmuebleUsuario> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<bool>> Handle(UpdateInmuebleUsuarioCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("InmuebleUsuario", request.Id);
            }

            _mapper.Map(request, entity);

            _repository.Update(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
