using System;
using BioEngine.Core.Entities;
using BioEngine.Core.Interfaces;

namespace BioEngine.BRC.Domain.Entities
{
    public class Developer : Section<DeveloperData>
    {
        public override string TypeTitle { get; set; } = "Разработчик";
    }

    public class DeveloperData : TypedData
    {
        public Person[] Persons { get; set; } = new Person[0];
    }

    public class Person
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public DateTimeOffset DateStart { get; set; }
        public DateTimeOffset? DateEnd { get; set; }
    }
}