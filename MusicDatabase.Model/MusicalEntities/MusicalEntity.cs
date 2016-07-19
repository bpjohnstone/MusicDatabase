using System.Collections.Generic;

namespace MusicDatabase.Model
{
    public abstract class MusicalEntity : Entity
    {
        #region Properties
        public string Name { get; set; }
        public string SortName { get; set; }

        public ICollection<DiscographyEntry> Discography { get; set; }
        public ICollection<Performance> Performances { get; set; }
        #endregion

        #region Constructors
        public MusicalEntity()
            : this("", "")
        {

        }

        public MusicalEntity(string name)
            : this(name, name)
        {

        }

        public MusicalEntity(string name, string sortName)
        {
            Name = name;
            SortName = sortName;

            Discography = new List<DiscographyEntry>();
            Performances = new List<Performance>();
        }
        #endregion
    }
}
