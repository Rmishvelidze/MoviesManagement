using MoviesManagement.Core.Domain.Basics;
using System;
using System.ComponentModel.DataAnnotations;

namespace MoviesManagement.Core.Domain.Entities
{
    public class Movie : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ShortDescription { get; set; }
        public string Image { get; set; }

        [Required]
        public int CinemaCompanyId { get; set; }


        public virtual CinemaCompany CinemaCompany { get; set; }
    }
}
