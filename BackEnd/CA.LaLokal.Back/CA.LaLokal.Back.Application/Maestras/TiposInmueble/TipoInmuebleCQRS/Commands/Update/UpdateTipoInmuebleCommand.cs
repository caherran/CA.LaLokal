using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.TiposInmueble;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.TiposInmueble.TipoInmuebleCQRS.Commands.Update
{
    public class UpdateTipoInmuebleCommand : IRequest<ResponseBase<bool>>, IMapFrom<TipoInmueble>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }

    public class UpdateTipoInmuebleCommandHandler : IRequestHandler<UpdateTipoInmuebleCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TipoInmueble> _repository;
        private readonly IMapper _mapper;

        public UpdateTipoInmuebleCommandHandler(IUnitOfWork unitOfWork, IRepository<TipoInmueble> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<bool>> Handle(UpdateTipoInmuebleCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("TipoInmueble", request.Id);
            }

            _mapper.Map(request, entity);

            _repository.Update(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
