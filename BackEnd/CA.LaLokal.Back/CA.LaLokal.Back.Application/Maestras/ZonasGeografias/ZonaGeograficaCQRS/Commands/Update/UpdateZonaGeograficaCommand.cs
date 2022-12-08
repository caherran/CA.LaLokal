using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.ZonasGeografias;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.ZonasGeografias.ZonaGeograficaCQRS.Commands.Update
{
    public class UpdateZonaGeograficaCommand : IRequest<ResponseBase<bool>>, IMapFrom<ZonaGeografica>
    {
        public int Id { get; set; }
        public int ZonaBarrioId { get; set; }

    }

    public class UpdateZonaGeograficaCommandHandler : IRequestHandler<UpdateZonaGeograficaCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<ZonaGeografica> _repository;
        private readonly IMapper _mapper;

        public UpdateZonaGeograficaCommandHandler(IUnitOfWork unitOfWork, IRepository<ZonaGeografica> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<bool>> Handle(UpdateZonaGeograficaCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("ZonaGeografica", request.Id);
            }

            _mapper.Map(request, entity);

            _repository.Update(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
