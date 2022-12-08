using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.TiposMoneda;
using CA.GuidGenerator;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.TiposMoneda.TipoMonedaCQRS.Commands.Create
{
    public class CreateTipoMonedaCommand : IRequest<ResponseBase<int>>, IMapFrom<TipoMoneda>
    {
        public string Descripcion { get; set; }

    }

    public class CreateTipoMonedaCommandHandler : IRequestHandler<CreateTipoMonedaCommand, ResponseBase<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TipoMoneda> _repository;
        private readonly IMapper _mapper;

        public CreateTipoMonedaCommandHandler(IUnitOfWork unitOfWork, IRepository<TipoMoneda> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<int>> Handle(CreateTipoMonedaCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<TipoMoneda>(request);
            //entity.Id = SequentialGuid.Create();
            _repository.Insert(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new ResponseBase<int>(entity.Id);
        }
    }
}
