using System;
using BioEngine.BRC.Common.Entities;
using JetBrains.Annotations;
using Sitko.Core.Repository.EntityFrameworkCore;

namespace BioEngine.BRC.Common.Repository
{
    [UsedImplicitly]
    public class PagesRepository : ContentEntityRepository<Page>
    {
        public PagesRepository(EFRepositoryContext<Page, Guid, BioContext> repositoryContext) : base(repositoryContext)
        {
        }
    }
}
