using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.TiposNegocio;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.TiposNegocio.TipoNegocioCQRS.Commands.Update
{
    public class UpdateTipoNegocioCommand : IRequest<ResponseBase<bool>>, IMapFrom<TipoNegocio>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }

    public class UpdateTipoNegocioCommandHandler : IRequestHandler<UpdateTipoNegocioCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TipoNegocio> _repository;
        private readonly IMapper _mapper;

        public UpdateTipoNegocioCommandHandler(IUnitOfWork unitOfWork, IRepository<TipoNegocio> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<bool>> Handle(UpdateTipoNegocioCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("TipoNegocio", request.Id);
            }

            _mapper.Map(request, entity);

            _repository.Update(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
