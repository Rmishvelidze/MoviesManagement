using AutoMapper;
using MoviesManagement.Core.Application.DTOs;
using MoviesManagement.Core.Application.Features.CinemaCompanies.Commands;
using MoviesManagement.Core.Domain.Entities;

namespace MoviesManagement.Core.Application.Mappings
{
    public class CinemaCompanyProfile : Profile
    {
        public CinemaCompanyProfile()
        {
            CreateMap<CinemaCompany, GetCinemaCompanyDto>();
            CreateMap<SetCinemaCompanyDto, CinemaCompany>();

            CreateMap<CreateCinemaCompanyCommand.Request, CinemaCompany>();
            CreateMap<UpdateCinemaCompanyCommand.Command, CinemaCompany>();
        }
    }
}
