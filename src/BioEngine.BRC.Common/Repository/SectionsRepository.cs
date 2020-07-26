using System;
using BioEngine.BRC.Common.Entities;
using JetBrains.Annotations;
using Sitko.Core.Repository.EntityFrameworkCore;

namespace BioEngine.BRC.Common.Repository
{
    [UsedImplicitly]
    public class SectionsRepository : SectionRepository<Section>
    {
        public SectionsRepository(EFRepositoryContext<Section, Guid, BioContext> repositoryContext) : base(
            repositoryContext)
        {
        }
    }
}
