using System;
using BioEngine.Core.Entities;
using BioEngine.Core.Interfaces;

namespace BioEngine.BRC.Domain.Entities
{
    [TypedEntity(1)]
    public class Developer : Section<DeveloperData>
    {
    }

    public class DeveloperData : TypedData
    {
        public Person[] Persons { get; set; }
    }

    public class Person
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public DateTimeOffset DateStart { get; set; }
        public DateTimeOffset? DateEnd { get; set; }
    }
}