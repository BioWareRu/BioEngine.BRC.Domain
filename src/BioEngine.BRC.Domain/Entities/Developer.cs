using System;
using System.ComponentModel.DataAnnotations.Schema;
using BioEngine.Core.DB;
using BioEngine.Core.Entities;

namespace BioEngine.BRC.Domain.Entities
{
    [TypedEntity("developer")]
    public class Developer : Section<DeveloperData>
    {
        public override string TypeTitle { get; set; } = "Разработчик";
        [NotMapped] public override string PublicUrl => $"/developers/{Url}/about.html";
        [NotMapped] public override string PostsUrl => $"/developers/{Url}/posts.html";
    }

    public class DeveloperData : ITypedData
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
