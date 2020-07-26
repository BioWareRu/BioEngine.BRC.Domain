using BioEngine.BRC.Common.Web.Api.Interfaces;
using Newtonsoft.Json;

namespace BioEngine.BRC.Common.Web.Api.Response
{
    public class ValidationErrorResponse : IErrorInterface
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Field { get; }

        public string Message { get; }

        public ValidationErrorResponse(string field, string message)
        {
            Field = field != string.Empty ? field : null;
            Message = message;
        }
    }
}