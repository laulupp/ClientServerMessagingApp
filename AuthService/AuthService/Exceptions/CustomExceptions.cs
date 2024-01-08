using System.Net;

namespace AuthService.Exceptions;

public class CustomExceptions
{
    public abstract class ApiException : Exception
    {
        public HttpStatusCode StatusCode { get; }

        protected ApiException(string message, HttpStatusCode statusCode) : base(message)
        {
            StatusCode = statusCode;
        }
    }

    public class UserNotFoundException : ApiException
    {
        public UserNotFoundException(string message) : base(message, HttpStatusCode.NotFound) { }
    }

    public class InvalidPasswordException : ApiException
    {
        public InvalidPasswordException(string message) : base(message, HttpStatusCode.Unauthorized) { }
    }

    public class UserAlreadyExistsException : ApiException
    {
        public UserAlreadyExistsException(string message) : base(message, HttpStatusCode.BadRequest) { }
    }
}
