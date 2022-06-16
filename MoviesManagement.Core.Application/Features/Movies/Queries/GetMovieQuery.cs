using AutoMapper;
using FluentValidation;
using MediatR;
using MoviesManagement.Core.Application.DTOs;
using MoviesManagement.Core.Application.Exceptions;
using MoviesManagement.Core.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace MoviesManagement.Core.Application.Features.Movies.Queries
{
    public class GetMovieQuery 
    {
        public class Request : IRequest<GetMovieDto>
        {
            public int Id { get; set; }

            public Request(int id) => Id = id;
        }

        public class Handler : IRequestHandler<Request, GetMovieDto>
        {
            private readonly IUnitOfWork _unit;
            private readonly IMapper _mapper;

            public Handler(IUnitOfWork unit, IMapper mapper)
            {
                _unit = unit;
                _mapper = mapper;
            }
            public async Task<GetMovieDto> Handle(Request request, CancellationToken cancellationToken)
            {
                var movie = await _unit.MovieRepository.ReadAsync(request.Id);
                if (movie == null)
                    throw new EntityNotFoundException("Record not found!");

                return await Task.FromResult(_mapper.Map<GetMovieDto>(movie));
            }
        }

        public class Validator : AbstractValidator<Request>
        {
            private readonly IUnitOfWork _unit;

            public Validator(IUnitOfWork unit)
            {
                _unit = unit;

                RuleFor(x => x.Id)
                    .NotNull().WithMessage($"Please, enter id.");
            }
        }
    }
}
