using System.Net;

namespace Common.Exceptions
{
    public class UnauthorizedException : BaseException
    {
        public UnauthorizedException(string errorMessage) : base(errorMessage)
        {
            StatusCode = HttpStatusCode.Unauthorized;
        }
    }
}
