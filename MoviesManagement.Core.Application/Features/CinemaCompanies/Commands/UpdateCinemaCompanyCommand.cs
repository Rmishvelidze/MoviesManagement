using AutoMapper;
using FluentValidation;
using MediatR;
using MoviesManagement.Core.Application.Interfaces;
using MoviesManagement.Core.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace MoviesManagement.Core.Application.Features.CinemaCompanies.Commands
{
    public class UpdateCinemaCompanyCommand
    {
        public class Command : IRequest
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public void SetId(int id) => Id = id;
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly IUnitOfWork _unit;
            private readonly IMapper _mapper;

            public Handler(IUnitOfWork unit, IMapper mapper)
            {
                _unit = unit;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(Command command, CancellationToken cancellationToken)
            {
                var cinemaCompany = _mapper.Map<CinemaCompany>(command);
                await _unit.CinemaCompanyRepository.UpdateAsync(cinemaCompany);
                return Unit.Value;
            }
        }

        public class Validator : AbstractValidator<Command>
        {
            private readonly IUnitOfWork _unit;

            public Validator(IUnitOfWork unit)
            {
                _unit = unit;

                RuleFor(c => c.Id)
                    .NotNull().WithMessage("Id must not be null.");

                RuleFor(c => c.Name)
                    .NotEmpty().WithMessage("Cinema company name must not be empty!");
            }
        }
    }
}
