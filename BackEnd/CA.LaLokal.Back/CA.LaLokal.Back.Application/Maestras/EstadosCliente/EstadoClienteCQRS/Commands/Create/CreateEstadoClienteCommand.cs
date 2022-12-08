using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.EstadosCliente;
using CA.GuidGenerator;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.EstadosCliente.EstadoClienteCQRS.Commands.Create
{
    public class CreateEstadoClienteCommand : IRequest<ResponseBase<int>>, IMapFrom<EstadoCliente>
    {
        public string Descripcion { get; set; }

    }

    public class CreateEstadoClienteCommandHandler : IRequestHandler<CreateEstadoClienteCommand, ResponseBase<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<EstadoCliente> _repository;
        private readonly IMapper _mapper;

        public CreateEstadoClienteCommandHandler(IUnitOfWork unitOfWork, IRepository<EstadoCliente> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<int>> Handle(CreateEstadoClienteCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<EstadoCliente>(request);
            //entity.Id = SequentialGuid.Create();
            _repository.Insert(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new ResponseBase<int>(entity.Id);
        }
    }
}
