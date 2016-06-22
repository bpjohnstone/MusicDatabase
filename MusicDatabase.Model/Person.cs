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
        public string Psuedonym { get; set; }
        public string Notes { get; set; }

        // Concerts
        public virtual ICollection<MusicalEvent> MusicalEvents { get; set; }

        // Gifts
        public virtual ICollection<Copy> GiftsGiven { get; set; }
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

            MusicalEvents = new List<MusicalEvent>();
            GiftsGiven = new List<Copy>();
        }
        #endregion
    }
}
