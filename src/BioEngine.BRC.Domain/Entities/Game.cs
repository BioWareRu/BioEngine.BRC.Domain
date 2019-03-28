using BioEngine.Core.Entities;

namespace BioEngine.BRC.Domain.Entities
{
    public class Game : Section<GameData>
    {
        public override string TypeTitle { get; set; } = "Игра";
    }

    public class GameData : TypedData
    {
        public Platform[] Platforms { get; set; }
    }

    public enum Platform
    {
        PC,
        Xbox,
        Xbox360,
        XboxOne,
        PSOne,
        PSTwo,
        PSThree,
        PSFour,
        Android,
        // ReSharper disable once InconsistentNaming
        iOS,
        MacOS,
        Linux
    }
}