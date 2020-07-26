using System.Collections.Generic;
using System.Threading.Tasks;
using BioEngine.BRC.Common.Entities.Abstractions;
using Sitko.Core.Repository;

namespace BioEngine.BRC.Common.Web.Api.Models
{
    public interface IRequestRestModel<TEntity>
        where TEntity : class, IEntity
    {
        Task<TEntity> GetEntityAsync(TEntity entity);
    }

    public interface IContentRequestRestModel<TEntity> : IRequestRestModel<TEntity>
        where TEntity : class, IEntity, IContentEntity
    {
        List<Entities.ContentBlock> Blocks { get; set; }
    }
}
