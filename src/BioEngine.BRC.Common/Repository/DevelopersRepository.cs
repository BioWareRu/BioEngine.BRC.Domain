using System;
using BioEngine.BRC.Common.Entities;
using Sitko.Core.Repository.EntityFrameworkCore;

namespace BioEngine.BRC.Common.Repository
{
    public class DevelopersRepository : SectionRepository<Developer>
    {
        public DevelopersRepository(EFRepositoryContext<Developer, Guid, BioContext> repositoryContext) : base(
            repositoryContext)
        {
        }
    }
}
