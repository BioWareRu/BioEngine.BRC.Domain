using System.Collections.Generic;
using System.Threading.Tasks;
using BioEngine.BRC.Common.Entities.Abstractions;
using Sitko.Core.Repository;

namespace BioEngine.BRC.Common.Web.Api.Models
{
    public interface IResponseRestModel<in TEntity>
        where TEntity : class, IEntity
    {
        Task SetEntityAsync(TEntity entity);
    }

    public interface IContentResponseRestModel<TEntity> : IResponseRestModel<TEntity>
        where TEntity : class, IEntity, IContentEntity
    {
        List<Entities.ContentBlock> Blocks { get; set; }
    }
}
