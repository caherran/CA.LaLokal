using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.TiposCliente;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.TiposCliente.TipoClienteCQRS.Commands.Update
{
    public class UpdateTipoClienteCommand : IRequest<ResponseBase<bool>>, IMapFrom<TipoCliente>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }

    public class UpdateTipoClienteCommandHandler : IRequestHandler<UpdateTipoClienteCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TipoCliente> _repository;
        private readonly IMapper _mapper;

        public UpdateTipoClienteCommandHandler(IUnitOfWork unitOfWork, IRepository<TipoCliente> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<bool>> Handle(UpdateTipoClienteCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("TipoCliente", request.Id);
            }

            _mapper.Map(request, entity);

            _repository.Update(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
