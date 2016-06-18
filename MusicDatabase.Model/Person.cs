using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDatabase.Model
{
    public class Person : Entity
    {
        #region Properties
        public string Name { get; set; }
        public string Notes { get; set; }

        // Concerts
        public virtual ICollection<Attendance> MusicalEvents { get; set; }

        // Gifts
        #endregion

        #region Constructors
        public Person()
            : this("", "")
        {

        }

        public Person(string name, string notes)
        {
            Name = name;
            Notes = notes;

            MusicalEvents = new List<Attendance>();
        }
        #endregion
    }
}
