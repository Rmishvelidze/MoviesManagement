using Microsoft.EntityFrameworkCore;
using MoviesManagement.Core.Application.Interfaces.Repositories;
using MoviesManagement.Core.Domain.Entities;
using System.Linq;

namespace MoviesManagement.Infrastructure.Persistence.Implementations.Repositories
{
    internal class CinemaCompanyRepository : Repository<CinemaCompany>, ICinemaCompanyRepository
    {
        public CinemaCompanyRepository(DataContext context) : base (context) { }

        public IQueryable<CinemaCompany> Including =>
            _context.CinemaCompanies.Include(x => x.Movies);
    }
}
