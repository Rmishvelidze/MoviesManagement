using MoviesManagement.Core.Application.Exceptions.Basic;
using System.Net;

namespace MoviesManagement.Core.Application.Exceptions
{
    public class ActionProhibitedException : EntityValidationException
    {
        public override HttpStatusCode StatusCode => HttpStatusCode.NotAcceptable;

        public ActionProhibitedException(string message) : base(message) { }
    }
}
