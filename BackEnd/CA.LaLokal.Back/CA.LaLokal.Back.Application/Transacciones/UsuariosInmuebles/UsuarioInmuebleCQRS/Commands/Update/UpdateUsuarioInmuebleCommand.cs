using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.UsuariosInmuebles;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Transacciones.UsuariosInmuebles.UsuarioInmuebleCQRS.Commands.Update
{
    public class UpdateUsuarioInmuebleCommand : IRequest<ResponseBase<bool>>, IMapFrom<UsuarioInmueble>
    {
        public Guid Id { get; set; }
public Guid UsuarioId { get; set; }
public Guid InmuebleId { get; set; }

    }

    public class UpdateUsuarioInmuebleCommandHandler : IRequestHandler<UpdateUsuarioInmuebleCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<UsuarioInmueble> _repository;
        private readonly IMapper _mapper;

        public UpdateUsuarioInmuebleCommandHandler(IUnitOfWork unitOfWork, IRepository<UsuarioInmueble> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<bool>> Handle(UpdateUsuarioInmuebleCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("UsuarioInmueble", request.Id);
            }

            _mapper.Map(request, entity);

            _repository.Update(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
