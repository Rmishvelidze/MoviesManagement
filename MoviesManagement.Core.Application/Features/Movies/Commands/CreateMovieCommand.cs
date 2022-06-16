using AutoMapper;
using FluentValidation;
using MediatR;
using MoviesManagement.Core.Application.Exceptions;
using MoviesManagement.Core.Application.Interfaces;
using MoviesManagement.Core.Domain.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MoviesManagement.Core.Application.Features.Movies.Commands
{
    public class CreateMovieCommand
    {
        public class Request : IRequest
        {
            public string Name { get; set; }
            public DateTime ReleaseDate { get; set; }
            public string ShortDescription { get; set; }
            public string CinemaCompanyName { get; set; }
            public string Image { get; set; }
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
                var cinemaCompanies = await _unit.CinemaCompanyRepository.ReadAsync();
                if (cinemaCompanies == null)
                    throw new EntityNotFoundException("Cinema company's record is empty :(.");
                var cinemaCompany = cinemaCompanies.FirstOrDefault(x => x.Name == request.CinemaCompanyName);
                if (cinemaCompany == null)
                    throw new EntityNotFoundException($"There isn't any cinema company named like {request.CinemaCompanyName}!");

                var movie = new Movie()
                {
                    Name = request.Name,
                    ReleaseDate = request.ReleaseDate,
                    ShortDescription = request.ShortDescription,
                    CinemaCompany = cinemaCompany,
                    CinemaCompanyId = cinemaCompany.Id,
                    Image = request.Image
                };

                
                //cinemaCompany.Movies.Add(movie);

                await _unit.MovieRepository.CreateAsync(movie);

                return Unit.Value;
            }
        }

        public class Validator : AbstractValidator<Request>
        {
            private readonly IUnitOfWork _unit;
            public Validator(IUnitOfWork unit)
            {
                _unit = unit;

                RuleFor(x => x.Name)
                    .NotNull().WithMessage("Movie's name is empty!");

                var cinemaCreatingDate = new DateTime(1895,12,2);
                RuleFor(x => x.ReleaseDate)
                    .GreaterThan(cinemaCreatingDate).WithMessage($"By this time cinema didn't exists.");
            }
        }
    }
}
