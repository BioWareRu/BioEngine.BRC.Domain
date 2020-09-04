using BioEngine.BRC.Common.Components;

namespace BioEngine.BRC.Common.Entities.Blocks
{
    [Entity("textblock")]
    public class TextBlock : ContentBlock<TextBlockData>
    {
        public override string TypeTitle => "Текст";
        public override string TypeIcon => "text_format";

        public override string ToString()
        {
            return Data.Text;
        }
    }

    public class TextBlockData : ContentBlockData
    {
        public string Text { get; set; } = "";
    }
}
