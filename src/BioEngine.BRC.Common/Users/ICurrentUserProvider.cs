using System.Threading.Tasks;

namespace BioEngine.BRC.Common.Users
{
    public interface ICurrentUserProvider
    {
        IUser? CurrentUser { get; }
        Task<string> GetAccessTokenAsync();
    }
}
