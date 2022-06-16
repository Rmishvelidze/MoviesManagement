using AutoMapper;
using MoviesManagement.Core.Application.DTOs;
using MoviesManagement.Core.Application.Features.Movies.Queries;
using MoviesManagement.Core.Domain.Entities;

namespace MoviesManagement.Core.Application.Mappings
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<SetMovieDto, Movie>().ReverseMap();

            CreateMap<Movie, GetMovieDto>();
            CreateMap<GetMovieDto, Movie>().ReverseMap();

            CreateMap<Movie, GetMoviesQuery.Request>().ReverseMap();
            CreateMap<Movie, GetMovieQuery.Request>().ReverseMap();
        }
    }
}
