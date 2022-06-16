using System;

namespace MoviesManagement.Core.Application.DTOs
{
    public class GetMovieDto
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ShortDescription { get; set; }
        public string CinemaCompanyName { get; set; }
        public string Image { get; set; }
    }
}
