using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Transacciones.InmueblesCompartir;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Transacciones.InmueblesCompartir.InmuebleCompartirCQRS.Commands.Update
{
    public class UpdateInmuebleCompartirCommand : IRequest<ResponseBase<bool>>, IMapFrom<InmuebleCompartir>
    {
        public Guid Id { get; set; }
public Guid InmuebleId { get; set; }
public Guid UsuarioId { get; set; }
public string Asunto { get; set; }

    }

    public class UpdateInmuebleCompartirCommandHandler : IRequestHandler<UpdateInmuebleCompartirCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<InmuebleCompartir> _repository;
        private readonly IMapper _mapper;

        public UpdateInmuebleCompartirCommandHandler(IUnitOfWork unitOfWork, IRepository<InmuebleCompartir> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<bool>> Handle(UpdateInmuebleCompartirCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("InmuebleCompartir", request.Id);
            }

            _mapper.Map(request, entity);

            _repository.Update(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
