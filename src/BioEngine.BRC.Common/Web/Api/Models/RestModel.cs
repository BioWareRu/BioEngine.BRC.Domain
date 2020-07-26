using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BioEngine.BRC.Common.Entities.Abstractions;
using BioEngine.BRC.Common.Properties;
using BioEngine.BRC.Common.Web.Api.Entities;

namespace BioEngine.BRC.Common.Web.Api.Models
{
    public abstract class RestModel<TEntity> where TEntity : class, IBioEntity
    {
        private readonly PropertiesProvider _propertiesProvider;
        public Guid Id { get; set; }
        public DateTimeOffset DateAdded { get; set; }
        public DateTimeOffset DateUpdated { get; set; }
        public List<PropertiesGroup> PropertiesGroups { get; set; }


        protected RestModel(PropertiesProvider propertiesProvider)
        {
            _propertiesProvider = propertiesProvider;
        }

        protected virtual async Task ParseEntityAsync(TEntity entity)
        {
            Id = entity.Id;
            DateAdded = entity.DateAdded;
            DateUpdated = entity.DateUpdated;
            PropertiesGroups = (await _propertiesProvider.GetAsync(entity))
                .Select(p => PropertiesGroup.Create(p, PropertiesProvider.GetSchema(p.Key))).ToList();
        }

        protected virtual Task<TEntity> FillEntityAsync(TEntity entity)
        {
            entity ??= CreateEntity();
            entity.Id = Id;
            return Task.FromResult(entity);
        }

        protected virtual TEntity CreateEntity()
        {
            return Activator.CreateInstance<TEntity>();
        }
    }
}
