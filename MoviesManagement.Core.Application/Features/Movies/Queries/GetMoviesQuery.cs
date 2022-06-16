using AutoMapper;
using MediatR;
using MoviesManagement.Core.Application.DTOs;
using MoviesManagement.Core.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MoviesManagement.Core.Application.Features.Movies.Queries
{
    public class GetMoviesQuery
    {
        public class Request : IRequest<IEnumerable<GetMovieDto>>
        {
            public string Name { get; set; }
            public DateTime ReleaseDate { get; set; }
            public string ShortDescription { get; set; }
            public string CinemaCompanyName { get; set; }
            public string Image { get; set; }
        }

        public class Handler : IRequestHandler<Request, IEnumerable<GetMovieDto>>
        {
            private readonly IUnitOfWork _unit;
            private readonly IMapper _mapper;

            public Handler(IUnitOfWork unit, IMapper mapper)
            {
                _unit = unit;
                _mapper = mapper;
            }

            public async Task<IEnumerable<GetMovieDto>> Handle(Request request, CancellationToken cancellationToken)
            { 
                var movies = await _unit.MovieRepository.ReadAsync();

                var moviesResponces = movies.Select(x => new GetMovieDto()
                {
                    Name = x.Name,
                    ReleaseDate = x.ReleaseDate,
                    ShortDescription = x.ShortDescription,
                    CinemaCompanyName = 
                        x.CinemaCompany == null ?
                            "Cinema company is anknown." : x.CinemaCompany.Name,
                    Image = x.Image
                }) ;
                return _mapper.Map<IEnumerable<GetMovieDto>>(moviesResponces);
            }
        }
    }
}
