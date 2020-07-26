using BioEngine.BRC.Common.Properties;

namespace BioEngine.BRC.Common.Seo
{
    [PropertiesSet("Seo", IsEditable = true)]
    public class SeoContentPropertiesSet : PropertiesSet
    {
        [PropertiesElement("Описание", PropertyElementType.LongString)]
        public string Description { get; set; } = "";

        [PropertiesElement("Ключевые слова")] public string Keywords { get; set; } = "";
    }
}
