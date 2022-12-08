using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CA.LaLokal.Back.Domain.Maestras.MediosCaptacion;
using CA.Repository.Abstractions;
using CA.Util.MediatRUtils;

namespace CA.LaLokal.Back.Application.Maestras.MediosCaptacion.MedioCaptacionCQRS.Queries
{
    public class GetMediosCaptacionQuery : IRequest<ResponseBase<List<MedioCaptacionDto>>>
    {
    }

    public class GetMediosCaptacionQueryHandler : IRequestHandler<GetMediosCaptacionQuery, ResponseBase<List<MedioCaptacionDto>>>
    {
        private readonly IRepository<MedioCaptacion> _repository;
        private readonly IMapper _mapper;

        public GetMediosCaptacionQueryHandler(IRepository<MedioCaptacion> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<ResponseBase<List<MedioCaptacionDto>>> Handle(GetMediosCaptacionQuery request, CancellationToken cancellationToken)
        {
            var dto = _repository.TableNoTracking.ProjectTo<MedioCaptacionDto>(_mapper.ConfigurationProvider);
            return Task.FromResult(new ResponseBase<List<MedioCaptacionDto>>(dto.ToList()));
        }
    }
}