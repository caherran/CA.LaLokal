using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.Garajes;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.Garajes.GarajeCQRS.Commands.Update
{
    public class UpdateGarajeCommand : IRequest<ResponseBase<bool>>, IMapFrom<Garaje>
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }

    public class UpdateGarajeCommandHandler : IRequestHandler<UpdateGarajeCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Garaje> _repository;
        private readonly IMapper _mapper;

        public UpdateGarajeCommandHandler(IUnitOfWork unitOfWork, IRepository<Garaje> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<bool>> Handle(UpdateGarajeCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("Garaje", request.Id);
            }

            _mapper.Map(request, entity);

            _repository.Update(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
