using System;

namespace MoviesManagement.Core.Application.DTOs
{
    public class SetMovieDto
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ShortDescription { get; set; }
        public string CinemaCompany { get; set; }
        public string Image { get; set; }
    }
}
