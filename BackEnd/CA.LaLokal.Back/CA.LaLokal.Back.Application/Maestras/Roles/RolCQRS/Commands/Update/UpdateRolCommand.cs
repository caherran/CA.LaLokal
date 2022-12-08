using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.Roles;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.Roles.RolCQRS.Commands.Update
{
    public class UpdateRolCommand : IRequest<ResponseBase<bool>>, IMapFrom<Rol>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }

    public class UpdateRolCommandHandler : IRequestHandler<UpdateRolCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Rol> _repository;
        private readonly IMapper _mapper;

        public UpdateRolCommandHandler(IUnitOfWork unitOfWork, IRepository<Rol> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<bool>> Handle(UpdateRolCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("Rol", request.Id);
            }

            _mapper.Map(request, entity);

            _repository.Update(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
