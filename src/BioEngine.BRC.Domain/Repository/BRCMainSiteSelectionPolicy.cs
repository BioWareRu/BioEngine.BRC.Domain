using System;
using System.Collections.Generic;
using System.Linq;
using BioEngine.Core.Entities;
using BioEngine.Core.Repository;

namespace BioEngine.BRC.Domain.Repository
{
    public class BRCMainSiteSelectionPolicy : IMainSiteSelectionPolicy
    {
        public Guid Get(ISiteEntity siteEntity)
        {
            return siteEntity.SiteIds.First();
        }

        public Guid Get(ISectionEntity contentEntity, IEnumerable<Section> sections)
        {
            return sections.First(s => s.Id == contentEntity.SectionIds.First()).MainSiteId;
        }
    }
}
