using System;
using BioEngine.BRC.Common.Entities;
using Sitko.Core.Repository.EntityFrameworkCore;

namespace BioEngine.BRC.Common.Repository
{
    public class ContentBlocksRepository : EFRepository<ContentBlock, Guid, BioContext>
    {
        public ContentBlocksRepository(EFRepositoryContext<ContentBlock, Guid, BioContext> repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
