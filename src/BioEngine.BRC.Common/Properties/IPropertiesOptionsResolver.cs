using System.Collections.Generic;
using System.Threading.Tasks;

namespace BioEngine.BRC.Common.Properties
{
    public interface IPropertiesOptionsResolver
    {
        bool CanResolve(PropertiesSet properties);
        Task<List<PropertiesOption>?> ResolveAsync(PropertiesSet properties, string property);
    }
}
