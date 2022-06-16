using AutoMapper;
using FluentValidation;
using MediatR;
using MoviesManagement.Core.Application.DTOs;
using MoviesManagement.Core.Application.Exceptions;
using MoviesManagement.Core.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace MoviesManagement.Core.Application.Features.CinemaCompanies.Queries
{
    public class GetCinemaCompanyQuery
    {
        public class Request : IRequest<GetCinemaCompanyDto>
        {
            public int Id { get; set; }
            public Request(int id) => this.Id = id;
        }

        public class Handler : IRequestHandler<Request, GetCinemaCompanyDto>
        {
            private readonly IUnitOfWork _unit;
            private readonly IMapper _mapper;

            public Handler(IUnitOfWork unit, IMapper mapper)
            {
                _unit = unit;
                _mapper = mapper;
            }

            public async Task<GetCinemaCompanyDto> Handle(Request request, CancellationToken cancellationToken)
            {
                var cinemaCompany = await _unit.CinemaCompanyRepository.ReadAsync(request.Id);
                if (cinemaCompany == null)
                    throw new EntityNotFoundException("Record Not found!");

                return await Task.FromResult(_mapper.Map<GetCinemaCompanyDto>(cinemaCompany));
            }
        }

        public class Validator : AbstractValidator<Request>
        {
            private readonly IUnitOfWork _unit;

            public Validator(IUnitOfWork unit)
            {
                _unit = unit;

                RuleFor(r => r.Id)
                    .NotNull().WithMessage($"Please, enter id.");
            }
        }
    }
}
