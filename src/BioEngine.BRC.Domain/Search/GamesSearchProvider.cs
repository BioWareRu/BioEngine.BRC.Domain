using System.Collections.Generic;
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
    public class GamesSearchProvider : SectionsSearchProvider<Game>
    {
        private readonly GamesRepository _gamesRepository;

        public GamesSearchProvider(ISearcher searcher, ILogger<BaseSearchProvider<Game>> logger,
            GamesRepository gamesRepository) : base(searcher,
            logger)
        {
            _gamesRepository = gamesRepository;
        }

        protected override async Task<IEnumerable<Game>> GetEntitiesAsync(IEnumerable<SearchModel> searchModels)
        {
            var ids = searchModels.Select(s => s.Id).Distinct().ToArray();
            return await _gamesRepository.GetByIdsAsync(ids);
        }
    }
}
