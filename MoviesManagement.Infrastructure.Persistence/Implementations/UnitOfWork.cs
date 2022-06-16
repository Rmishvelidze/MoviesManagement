using MoviesManagement.Core.Application.Interfaces;
using MoviesManagement.Core.Application.Interfaces.Repositories;
using MoviesManagement.Infrastructure.Persistence.Implementations.Repositories;

namespace MoviesManagement.Infrastructure.Persistence.Implementations
{
    internal class UnitOfWork : IUnitOfWork
    {
        private IMovieRepository _movieRepository;
        private ICinemaCompanyRepository _cinemaCompanyRepository;

        private readonly DataContext _context;
        public UnitOfWork(DataContext context) => _context = context;

        public IMovieRepository MovieRepository => _movieRepository ??= new MovieRepository(_context);
        public ICinemaCompanyRepository CinemaCompanyRepository => _cinemaCompanyRepository ??= new CinemaCompanyRepository(_context);
    }
}
