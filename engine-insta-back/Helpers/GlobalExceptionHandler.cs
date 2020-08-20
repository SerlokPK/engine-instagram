using Common.Exceptions;
using NLog;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;

namespace engine_insta_back.Helpers
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly Logger m_Logger = LogManager.GetCurrentClassLogger();
        public Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            var exception = context.Exception;
            var statusCode = HttpStatusCode.InternalServerError;

            if (exception != null)
            {
                var errorMessage = exception.Message;
                if (exception is BaseException be)
                {
                    statusCode = be.StatusCode;
                }
                m_Logger.Error(exception, context.Request.RequestUri.AbsoluteUri);
                var response = context.Request.CreateResponse(statusCode, new { errorMessage });
                context.Result = new ResponseMessageResult(response);
            }


            return Task.CompletedTask;
        }
    }
}