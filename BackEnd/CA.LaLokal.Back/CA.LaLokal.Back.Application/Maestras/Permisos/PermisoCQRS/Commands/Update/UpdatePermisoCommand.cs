using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.Permisos;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.Permisos.PermisoCQRS.Commands.Update
{
    public class UpdatePermisoCommand : IRequest<ResponseBase<bool>>, IMapFrom<Permiso>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int FuncionalIdadId { get; set; }

    }

    public class UpdatePermisoCommandHandler : IRequestHandler<UpdatePermisoCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Permiso> _repository;
        private readonly IMapper _mapper;

        public UpdatePermisoCommandHandler(IUnitOfWork unitOfWork, IRepository<Permiso> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<bool>> Handle(UpdatePermisoCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("Permiso", request.Id);
            }

            _mapper.Map(request, entity);

            _repository.Update(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
