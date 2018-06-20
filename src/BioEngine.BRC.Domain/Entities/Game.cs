using BioEngine.Core.Entities;
using BioEngine.Core.Interfaces;

namespace BioEngine.BRC.Domain.Entities
{
    [TypedEntity(2)]
    public class Game : Section<GameData>
    {
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
        iOS,
        MacOS,
        Linux
    }
}