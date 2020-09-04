using BioEngine.BRC.Common.Components;

namespace BioEngine.BRC.Common.Entities.Blocks
{
    [Entity("cutblock")]
    public class CutBlock : ContentBlock<CutBlockData>
    {
        public override string? TypeTitle => "Кат";
        public override string TypeIcon => "content_cut";

        public override string ToString()
        {
            return "";
        }
    }

    public class CutBlockData : ContentBlockData
    {
        public string ButtonText { get; set; } = "Читать дальше";
    }
}
