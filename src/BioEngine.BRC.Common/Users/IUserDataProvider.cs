using System.Collections.Generic;
using System.Threading.Tasks;

namespace BioEngine.BRC.Common.Users
{
    public interface IUserDataProvider
    {
        Task<List<IUser>> GetDataAsync(string[] userIds);
    }
}
