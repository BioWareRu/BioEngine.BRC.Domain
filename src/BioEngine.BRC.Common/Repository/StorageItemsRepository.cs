using System;
using BioEngine.BRC.Common.Entities;
using Sitko.Core.Repository.EntityFrameworkCore;

namespace BioEngine.BRC.Common.Repository
{
    public class StorageItemsRepository : EFRepository<StorageItem, Guid, BioContext>
    {
        public StorageItemsRepository(EFRepositoryContext<StorageItem, Guid, BioContext> repositoryContext) :
            base(repositoryContext)
        {
        }
    }
}
