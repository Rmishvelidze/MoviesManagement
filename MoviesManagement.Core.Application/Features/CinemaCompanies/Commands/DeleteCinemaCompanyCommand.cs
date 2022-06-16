using MediatR;
using MoviesManagement.Core.Application.Exceptions;
using MoviesManagement.Core.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace MoviesManagement.Core.Application.Features.CinemaCompanies.Commands
{
    public class DeleteCinemaCompanyCommand
    {
        public class Request : IRequest
        {
            public int Id { get; set; }

            public Request(int id) => this.Id = id;
        }

        public class Handler : IRequestHandler<Request>
        {
            private readonly IUnitOfWork _unit;

            public Handler(IUnitOfWork unit)
            {
                _unit = unit;
            }
            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                var target = await _unit.CinemaCompanyRepository.ReadAsync(request.Id);
                if (target == null)
                    throw new EntityNotFoundException("Record not found!");
                await _unit.CinemaCompanyRepository.DeleteAsync(target.Id);
                return Unit.Value;
            }
        }
    }
}
