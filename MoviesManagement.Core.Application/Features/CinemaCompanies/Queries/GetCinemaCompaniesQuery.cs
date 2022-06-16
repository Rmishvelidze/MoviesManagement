using AutoMapper;
using MediatR;
using MoviesManagement.Core.Application.DTOs;
using MoviesManagement.Core.Application.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MoviesManagement.Core.Application.Features.CinemaCompanies.Queries
{
    public class GetCinemaCompaniesQuery
    {
        public class Request : IRequest<IEnumerable<GetCinemaCompanyDto>>
        {

        }

        public class Handler : IRequestHandler<Request, IEnumerable<GetCinemaCompanyDto>>
        {
            private IUnitOfWork _unit;
            private IMapper _mapper;

            public Handler(IUnitOfWork unit, IMapper mapper)
            {
                _unit = unit;
                _mapper = mapper;
            }
            public async Task<IEnumerable<GetCinemaCompanyDto>> Handle(Request request, CancellationToken cancellationToken)
            {
                var cinemaCompanies = await _unit.CinemaCompanyRepository.ReadAsync();
                return _mapper.Map<IEnumerable<GetCinemaCompanyDto>>(cinemaCompanies);
            }
        }
    }
}
