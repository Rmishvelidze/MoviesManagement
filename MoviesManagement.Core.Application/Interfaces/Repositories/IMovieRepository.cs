using MoviesManagement.Core.Domain.Entities;

namespace MoviesManagement.Core.Application.Interfaces.Repositories
{
    public interface IMovieRepository : IRepository<int, Movie>
    {
    }
}
