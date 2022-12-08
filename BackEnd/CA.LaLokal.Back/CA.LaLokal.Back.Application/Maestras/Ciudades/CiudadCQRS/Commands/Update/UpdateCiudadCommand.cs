using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.Ciudades;
using CA.Domain.Auditable.Exceptions;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;
using CA.Utils.AutoMapperUtils;

namespace CA.LaLokal.Back.Application.Maestras.Ciudades.CiudadCQRS.Commands.Update
{
    public class UpdateCiudadCommand : IRequest<ResponseBase<bool>>, IMapFrom<Ciudad>
    {
        public int Id { get; set; }
        public int DepartamentoId { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }

    }

    public class UpdateCiudadCommandHandler : IRequestHandler<UpdateCiudadCommand, ResponseBase<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Ciudad> _repository;
        private readonly IMapper _mapper;

        public UpdateCiudadCommandHandler(IUnitOfWork unitOfWork, IRepository<Ciudad> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseBase<bool>> Handle(UpdateCiudadCommand request, CancellationToken cancellationToken)
        {
            var entity = _repository.GetById(request.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException("Ciudad", request.Id);
            }

            _mapper.Map(request, entity);

            _repository.Update(entity);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResponseBase<bool>(true);
        }
    }
}
