using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.Banos;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.Banos.BanoCQRS.Commands.Update
{
    public class UpdateBanoCommand : IRequest<ResponseBase<bool>>, IMapFrom<Bano>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }

    public class UpdateBanoCommandHandler : IRequestHandler<UpdateBanoCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Bano> _repository;
        private readonly IMapper _mapper;

        public UpdateBanoCommandHandler(IUnitOfWork unitOfWork, IRepository<Bano> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<bool>> Handle(UpdateBanoCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("Bano", request.Id);
            }

            _mapper.Map(request, entity);

            _repository.Update(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
