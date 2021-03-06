using AutoMapper;
using FluentValidation;
using MediatR;
using MoviesManagement.Core.Application.Interfaces;
using MoviesManagement.Core.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace MoviesManagement.Core.Application.Features.CinemaCompanies.Commands
{
    public class CreateCinemaCompanyCommand
    {
        public class Request : IRequest
        {
            public string Name { get; set; }
        }

        public class Handler : IRequestHandler<Request>
        {
            private readonly IUnitOfWork _unit;
            private readonly IMapper _mapper;

            public Handler(IUnitOfWork unit, IMapper mapper)
            {
                _unit = unit;
                _mapper = mapper;
            }
            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                var cinemaCompany = _mapper.Map<CinemaCompany>(request);
                await _unit.CinemaCompanyRepository.CreateAsync(cinemaCompany);
                return Unit.Value;
            }
        }

        public class Validator : AbstractValidator<Request>
        {
            private readonly IUnitOfWork _unit;

            public Validator(IUnitOfWork unit)
            {
                _unit = unit;

                RuleFor(r => r.Name)
                    .NotEmpty().WithMessage("Cinema company name must not be empty!");
            }
        }
    }
}
