using System;
using BioEngine.Core.Entities;
using BioEngine.Core.Interfaces;

namespace BioEngine.BRC.Domain.Entities
{
    public class Post : ContentItem<PostData>
    {
        public override string TypeTitle { get; set; } = "Пост";

        private (string shortText, string longText)? _texts;

        public string GetShortText()
        {
            ParseText();
            return _texts?.shortText;
        }

        private void ParseText()
        {
            if (_texts != null) return;
            if (!string.IsNullOrEmpty(Data?.Text) && Data.Text.Contains("[cut]"))
            {
                var parts = Data.Text.Split(new[] {"[cut]"}, StringSplitOptions.RemoveEmptyEntries);
                _texts = (parts[0], parts[1]);
            }
            else
            {
                _texts = (Data?.Text, null);
            }
        }

        public string GetFullText()
        {
            ParseText();
            return _texts?.longText;
        }
    }

    public class PostData : TypedData
    {
        public string Text { get; set; }
    }
}