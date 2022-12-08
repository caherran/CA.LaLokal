using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.Roles;
using CA.GuidGenerator;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.Roles.RolCQRS.Commands.Create
{
    public class CreateRolCommand : IRequest<ResponseBase<int>>, IMapFrom<Rol>
    {
        public string Descripcion { get; set; }

    }

    public class CreateRolCommandHandler : IRequestHandler<CreateRolCommand, ResponseBase<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Rol> _repository;
        private readonly IMapper _mapper;

        public CreateRolCommandHandler(IUnitOfWork unitOfWork, IRepository<Rol> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<int>> Handle(CreateRolCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Rol>(request);
            //entity.Id = SequentialGuid.Create();
            _repository.Insert(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new ResponseBase<int>(entity.Id);
        }
    }
}
