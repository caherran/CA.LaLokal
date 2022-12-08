using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.TiposMoneda;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.TiposMoneda.TipoMonedaCQRS.Commands.Update
{
    public class UpdateTipoMonedaCommand : IRequest<ResponseBase<bool>>, IMapFrom<TipoMoneda>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }

    public class UpdateTipoMonedaCommandHandler : IRequestHandler<UpdateTipoMonedaCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TipoMoneda> _repository;
        private readonly IMapper _mapper;

        public UpdateTipoMonedaCommandHandler(IUnitOfWork unitOfWork, IRepository<TipoMoneda> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<bool>> Handle(UpdateTipoMonedaCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("TipoMoneda", request.Id);
            }

            _mapper.Map(request, entity);

            _repository.Update(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
