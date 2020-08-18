using System.Net;

namespace Common.Exceptions
{
    public class BadRequestException : BaseException
    {
        public BadRequestException(string errorMessage) : base(errorMessage)
        {
            StatusCode = HttpStatusCode.BadRequest;
        }
    }
}
