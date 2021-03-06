using System.Linq;
using System.Threading.Tasks;
using BioEngine.BRC.Domain.Entities;
using BioEngine.BRC.Domain.Repository;
using BioEngine.Core.Search;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;

namespace BioEngine.BRC.Domain.Search
{
    [UsedImplicitly]
    public class DevelopersSearchProvider : SectionsSearchProvider<Developer>
    {
        private readonly DevelopersRepository _developersRepository;

        public DevelopersSearchProvider(ILogger<DevelopersSearchProvider> logger,
            DevelopersRepository developersRepository, ISearcher searcher = null) :
            base(logger, searcher)
        {
            _developersRepository = developersRepository;
        }

        protected override Task<Developer[]> GetEntitiesAsync(SearchModel[] searchModels)
        {
            var ids = searchModels.Select(s => s.Id).Distinct().ToArray();
            return _developersRepository.GetByIdsAsync(ids);
        }
    }
}
