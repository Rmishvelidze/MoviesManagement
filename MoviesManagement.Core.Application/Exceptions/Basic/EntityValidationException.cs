using System;
using System.Net;

namespace MoviesManagement.Core.Application.Exceptions.Basic
{
    public abstract class EntityValidationException : Exception
    {
        public abstract HttpStatusCode StatusCode { get; }

        public EntityValidationException(string message) : base(message) { }
    }
}
