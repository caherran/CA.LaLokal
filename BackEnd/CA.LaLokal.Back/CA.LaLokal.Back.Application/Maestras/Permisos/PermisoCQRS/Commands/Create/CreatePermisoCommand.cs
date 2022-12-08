using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.Permisos;
using CA.GuidGenerator;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.Permisos.PermisoCQRS.Commands.Create
{
    public class CreatePermisoCommand : IRequest<ResponseBase<int>>, IMapFrom<Permiso>
    {
        public string Descripcion { get; set; }
        public int FuncionalIdadId { get; set; }

    }

    public class CreatePermisoCommandHandler : IRequestHandler<CreatePermisoCommand, ResponseBase<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Permiso> _repository;
        private readonly IMapper _mapper;

        public CreatePermisoCommandHandler(IUnitOfWork unitOfWork, IRepository<Permiso> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<int>> Handle(CreatePermisoCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Permiso>(request);
            //entity.Id = SequentialGuid.Create();
            _repository.Insert(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new ResponseBase<int>(entity.Id);
        }
    }
}
