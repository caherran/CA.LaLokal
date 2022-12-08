using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.Pisos;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.Pisos.PisoCQRS.Commands.Update
{
    public class UpdatePisoCommand : IRequest<ResponseBase<bool>>, IMapFrom<Piso>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }

    public class UpdatePisoCommandHandler : IRequestHandler<UpdatePisoCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Piso> _repository;
        private readonly IMapper _mapper;

        public UpdatePisoCommandHandler(IUnitOfWork unitOfWork, IRepository<Piso> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<bool>> Handle(UpdatePisoCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("Piso", request.Id);
            }

            _mapper.Map(request, entity);

            _repository.Update(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
