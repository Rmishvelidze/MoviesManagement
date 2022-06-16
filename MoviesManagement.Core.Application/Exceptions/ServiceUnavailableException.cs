using MoviesManagement.Core.Application.Exceptions.Basic;
using System.Net;

namespace MoviesManagement.Core.Application.Exceptions
{
    public class ServiceUnavailableException : EntityValidationException
    {
        public override HttpStatusCode StatusCode => HttpStatusCode.ServiceUnavailable;

        public ServiceUnavailableException(string message) : base(message) { }
    }
}
