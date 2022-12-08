using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.PermisosRol;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.PermisosRol.PermisoRolCQRS.Commands.Update
{
    public class UpdatePermisoRolCommand : IRequest<ResponseBase<bool>>, IMapFrom<PermisoRol>
    {
        public int Id { get; set; }
        public int RolId { get; set; }
        public int PermisoId { get; set; }
        public string Estatus { get; set; }

    }

    public class UpdatePermisoRolCommandHandler : IRequestHandler<UpdatePermisoRolCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<PermisoRol> _repository;
        private readonly IMapper _mapper;

        public UpdatePermisoRolCommandHandler(IUnitOfWork unitOfWork, IRepository<PermisoRol> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<bool>> Handle(UpdatePermisoRolCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("PermisoRol", request.Id);
            }

            _mapper.Map(request, entity);

            _repository.Update(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
