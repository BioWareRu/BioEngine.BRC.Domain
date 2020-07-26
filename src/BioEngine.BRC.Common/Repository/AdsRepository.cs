using System;
using BioEngine.BRC.Common.Entities;
using Sitko.Core.Repository.EntityFrameworkCore;

namespace BioEngine.BRC.Common.Repository
{
    public class AdsRepository : ContentEntityRepository<Ad>
    {
        public AdsRepository(EFRepositoryContext<Ad, Guid, BioContext> repositoryContext) : base(repositoryContext)
        {
        }
    }
}
