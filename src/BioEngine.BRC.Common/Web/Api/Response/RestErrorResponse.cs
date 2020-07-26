using BioEngine.BRC.Common.Web.Api.Interfaces;

namespace BioEngine.BRC.Common.Web.Api.Response
{
    public class RestErrorResponse : IErrorInterface
    {
        public RestErrorResponse(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }
}