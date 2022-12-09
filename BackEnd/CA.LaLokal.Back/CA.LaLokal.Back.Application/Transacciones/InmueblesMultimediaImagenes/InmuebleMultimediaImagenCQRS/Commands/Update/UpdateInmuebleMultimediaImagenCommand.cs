using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.InmueblesMultimediaImagenes;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Transacciones.InmueblesMultimediaImagenes.InmuebleMultimediaImagenCQRS.Commands.Update
{
    public class UpdateInmuebleMultimediaImagenCommand : IRequest<ResponseBase<bool>>, IMapFrom<InmuebleMultimediaImagen>
    {
        public Guid Id { get; set; }
public Guid InmuebleId { get; set; }
public string URLImagen { get; set; }

    }

    public class UpdateInmuebleMultimediaImagenCommandHandler : IRequestHandler<UpdateInmuebleMultimediaImagenCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<InmuebleMultimediaImagen> _repository;
        private readonly IMapper _mapper;

        public UpdateInmuebleMultimediaImagenCommandHandler(IUnitOfWork unitOfWork, IRepository<InmuebleMultimediaImagen> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<bool>> Handle(UpdateInmuebleMultimediaImagenCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("InmuebleMultimediaImagen", request.Id);
            }

            _mapper.Map(request, entity);

            _repository.Update(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
