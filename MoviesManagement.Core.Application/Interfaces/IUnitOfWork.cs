using MoviesManagement.Core.Application.Interfaces.Repositories;

namespace MoviesManagement.Core.Application.Interfaces
{
    public interface IUnitOfWork
    {
        public IMovieRepository MovieRepository { get; }
        public ICinemaCompanyRepository CinemaCompanyRepository { get; }
    }
}
