using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.PermisosRol;
using CA.GuidGenerator;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.PermisosRol.PermisoRolCQRS.Commands.Create
{
    public class CreatePermisoRolCommand : IRequest<ResponseBase<int>>, IMapFrom<PermisoRol>
    {
        public int RolId { get; set; }
        public int PermisoId { get; set; }
        public string Estatus { get; set; }

    }

    public class CreatePermisoRolCommandHandler : IRequestHandler<CreatePermisoRolCommand, ResponseBase<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<PermisoRol> _repository;
        private readonly IMapper _mapper;

        public CreatePermisoRolCommandHandler(IUnitOfWork unitOfWork, IRepository<PermisoRol> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<int>> Handle(CreatePermisoRolCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<PermisoRol>(request);
            //entity.Id = SequentialGuid.Create();
            _repository.Insert(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new ResponseBase<int>(entity.Id);
        }
    }
}
