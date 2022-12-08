using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.Estratos;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.Estratos.EstratoCQRS.Commands.Update
{
    public class UpdateEstratoCommand : IRequest<ResponseBase<bool>>, IMapFrom<Estrato>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }

    public class UpdateEstratoCommandHandler : IRequestHandler<UpdateEstratoCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Estrato> _repository;
        private readonly IMapper _mapper;

        public UpdateEstratoCommandHandler(IUnitOfWork unitOfWork, IRepository<Estrato> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<bool>> Handle(UpdateEstratoCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("Estrato", request.Id);
            }

            _mapper.Map(request, entity);

            _repository.Update(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
