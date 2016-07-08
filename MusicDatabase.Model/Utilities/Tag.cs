using System;

namespace MusicDatabase.Model
{
    public class Tag
    {
        public Guid ID { get; set; }

        public virtual TaggedEntity Entity { get; set; }

        // This is included, so the database will use the same naming conventions as the other foreign keys
        public Guid EntityID { get; set; } 

        public string Type { get; set; }
        public string Data { get; set; }

        public Tag()
            : this("", "")
        {

        }

        public Tag(string type)
            : this(type, "")
        {

        }

        public Tag(string type, string data)
        {
            ID = Guid.NewGuid();
            Type = type;
            Data = data;
        }
    }
}
