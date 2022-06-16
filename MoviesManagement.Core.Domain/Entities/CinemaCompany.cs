using MoviesManagement.Core.Domain.Basics;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoviesManagement.Core.Domain.Entities
{
    public class CinemaCompany : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Movie> Movies { get; set; } 
    }
}
