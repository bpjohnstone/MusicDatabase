using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDatabase.Model
{
    public abstract class MusicalEntity : Entity
    {
        #region Properties
        public string Name { get; set; }
        public string SortName { get; set; }

        public virtual ICollection<DiscographyEntry> Discography { get; set; }
        public virtual ICollection<Performance> Performances { get; set; }
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
