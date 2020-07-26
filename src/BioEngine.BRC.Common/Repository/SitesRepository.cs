using System;
using BioEngine.BRC.Common.Entities;
using JetBrains.Annotations;
using Sitko.Core.Repository.EntityFrameworkCore;

namespace BioEngine.BRC.Common.Repository
{
    [UsedImplicitly]
    public class SitesRepository : EFRepository<Site, Guid, BioContext>
    {
        public SitesRepository(EFRepositoryContext<Site, Guid, BioContext> repositoryContext) : base(
            repositoryContext)
        {
        }
    }
}
