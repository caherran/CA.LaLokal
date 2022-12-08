using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.EstadosFisicoPropiedad;
using CA.GuidGenerator;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.EstadosFisicoPropiedad.EstadoFisicoPropiedadCQRS.Commands.Create
{
    public class CreateEstadoFisicoPropiedadCommand : IRequest<ResponseBase<int>>, IMapFrom<EstadoFisicoPropiedad>
    {
        public string Descripcion { get; set; }

    }

    public class CreateEstadoFisicoPropiedadCommandHandler : IRequestHandler<CreateEstadoFisicoPropiedadCommand, ResponseBase<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<EstadoFisicoPropiedad> _repository;
        private readonly IMapper _mapper;

        public CreateEstadoFisicoPropiedadCommandHandler(IUnitOfWork unitOfWork, IRepository<EstadoFisicoPropiedad> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<int>> Handle(CreateEstadoFisicoPropiedadCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<EstadoFisicoPropiedad>(request);
            //entity.Id = SequentialGuid.Create();
            _repository.Insert(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new ResponseBase<int>(entity.Id);
        }
    }
}
