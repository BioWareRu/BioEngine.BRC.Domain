using JetBrains.Annotations;

namespace BioEngine.BRC.Common.Web.Api.Response
{
    public class SaveModelResponse<T> : RestResponse
    {
        public SaveModelResponse(int code, T model) : base(code)
        {
            Model = model;
        }

        [UsedImplicitly] public T Model { get; }
    }
}