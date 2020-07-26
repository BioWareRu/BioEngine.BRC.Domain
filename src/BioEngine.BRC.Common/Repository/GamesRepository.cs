using System;
using BioEngine.BRC.Common.Entities;
using Sitko.Core.Repository.EntityFrameworkCore;

namespace BioEngine.BRC.Common.Repository
{
    public sealed class GamesRepository : SectionRepository<Game>
    {
        public GamesRepository(EFRepositoryContext<Game, Guid, BioContext> repositoryContext) : base(
            repositoryContext)
        {
        }
    }
}
