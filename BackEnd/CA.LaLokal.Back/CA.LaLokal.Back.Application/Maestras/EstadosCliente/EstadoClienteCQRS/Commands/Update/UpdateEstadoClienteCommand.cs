using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.EstadosCliente;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.EstadosCliente.EstadoClienteCQRS.Commands.Update
{
    public class UpdateEstadoClienteCommand : IRequest<ResponseBase<bool>>, IMapFrom<EstadoCliente>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }

    public class UpdateEstadoClienteCommandHandler : IRequestHandler<UpdateEstadoClienteCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<EstadoCliente> _repository;
        private readonly IMapper _mapper;

        public UpdateEstadoClienteCommandHandler(IUnitOfWork unitOfWork, IRepository<EstadoCliente> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<bool>> Handle(UpdateEstadoClienteCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("EstadoCliente", request.Id);
            }

            _mapper.Map(request, entity);

            _repository.Update(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
