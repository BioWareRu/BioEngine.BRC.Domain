using System.Collections.Generic;
using BioEngine.BRC.Common.Web.Api.Interfaces;

namespace BioEngine.BRC.Common.Web.Api.Response
{
    public class RestResponse
    {
        public RestResponse(int code, IEnumerable<IErrorInterface> errors = null)
        {
            Code = code;
            if (errors != null)
            {
                Errors = errors;
            }
        }

        public int Code { get; }

        public IEnumerable<IErrorInterface> Errors { get; protected set; }
    }
}