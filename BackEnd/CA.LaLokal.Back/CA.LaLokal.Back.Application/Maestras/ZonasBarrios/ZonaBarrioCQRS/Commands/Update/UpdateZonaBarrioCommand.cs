using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.ZonasBarrios;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.ZonasBarrios.ZonaBarrioCQRS.Commands.Update
{
    public class UpdateZonaBarrioCommand : IRequest<ResponseBase<bool>>, IMapFrom<ZonaBarrio>
    {
        public int Id { get; set; }
        public int CiudadId { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }

    }

    public class UpdateZonaBarrioCommandHandler : IRequestHandler<UpdateZonaBarrioCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<ZonaBarrio> _repository;
        private readonly IMapper _mapper;

        public UpdateZonaBarrioCommandHandler(IUnitOfWork unitOfWork, IRepository<ZonaBarrio> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<bool>> Handle(UpdateZonaBarrioCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("ZonaBarrio", request.Id);
            }

            _mapper.Map(request, entity);

            _repository.Update(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
