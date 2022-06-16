using Microsoft.EntityFrameworkCore;
using MoviesManagement.Core.Application.Interfaces.Repositories;
using MoviesManagement.Core.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesManagement.Infrastructure.Persistence.Implementations.Repositories
{
    internal class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(DataContext context) : base(context) { }

        public IQueryable<Movie> Movies =>
            _context.Movies.Include(x => x.CinemaCompany);

        public override async Task<IEnumerable<Movie>> ReadAsync() =>
            await Movies.ToListAsync();

        public override async Task<Movie> ReadAsync(int id) =>
            await Movies.FirstOrDefaultAsync(x => x.Id == id);
    }
}
