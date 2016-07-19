using System.Collections.Generic;
using System.Linq;

namespace MusicDatabase.Model
{
    // Extends an Entity, and allows "Tags" to be added to it, which basically just add some extra attributes.

    // A Release can be tagged with "Live", "Remix", "Soundtrack", etc
    // A Copy can be tagged with "Secondhand", "Record Store Day Item", etc

    // See the Constants file for a list of defined tags

    public abstract class TaggedEntity : Entity
    {
        public ICollection<Tag> Tags { get; set; }

        public TaggedEntity()
        {
            Tags = new List<Tag>();
        }

        public bool HasTag(string tagType)
        {
            return Tags.Count(t => t.Type == tagType) > 0;
        }
    }
}
