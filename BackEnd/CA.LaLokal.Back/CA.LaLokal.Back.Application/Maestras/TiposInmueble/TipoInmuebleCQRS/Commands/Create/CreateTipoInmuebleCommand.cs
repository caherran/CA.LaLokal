using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.TiposInmueble;
using CA.GuidGenerator;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.TiposInmueble.TipoInmuebleCQRS.Commands.Create
{
    public class CreateTipoInmuebleCommand : IRequest<ResponseBase<int>>, IMapFrom<TipoInmueble>
    {
        public string Descripcion { get; set; }

    }

    public class CreateTipoInmuebleCommandHandler : IRequestHandler<CreateTipoInmuebleCommand, ResponseBase<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TipoInmueble> _repository;
        private readonly IMapper _mapper;

        public CreateTipoInmuebleCommandHandler(IUnitOfWork unitOfWork, IRepository<TipoInmueble> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<int>> Handle(CreateTipoInmuebleCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<TipoInmueble>(request);
            //entity.Id = SequentialGuid.Create();
            _repository.Insert(entity);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new ResponseBase<int>(entity.Id);
        }
    }
}
