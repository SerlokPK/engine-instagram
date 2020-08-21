namespace Common.Exceptions
{
    public class ConflictException : BaseException
    {
        public ConflictException(string errorMessage) : base(errorMessage)
        {
            StatusCode = System.Net.HttpStatusCode.Conflict;
        }
    }
}
