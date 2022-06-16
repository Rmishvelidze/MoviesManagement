using MoviesManagement.Core.Application.Exceptions.Basic;
using System.Net;

namespace MoviesManagement.Core.Application.Exceptions
{
    public class EntityAlreadyExistsException : EntityValidationException
    {
        public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

        public EntityAlreadyExistsException(string message) : base(message) { }
    }
}
