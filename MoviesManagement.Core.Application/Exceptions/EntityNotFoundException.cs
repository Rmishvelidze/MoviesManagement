using MoviesManagement.Core.Application.Exceptions.Basic;
using System.Net;

namespace MoviesManagement.Core.Application.Exceptions
{
    public class EntityNotFoundException : EntityValidationException
    {
        public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;

        public EntityNotFoundException(string message) : base(message) { }
    }
}
