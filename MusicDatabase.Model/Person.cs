using System.Collections.Generic;
using System.Linq;

namespace MusicDatabase.Model
{
    public class Person : Entity
    {
        #region Properties
        public string Name { get; set; }
        public string Psuedonym { get; set; }
        public string Notes { get; set; }

        // Events
        public ICollection<MusicalEvent> EventsAttended { get; set; }
        public int TotalEvents
        {
            get
            {
                return EventsAttended.Count(e => e is SingleDayEvent) + EventsAttended.OfType<MultiDayFestival>().Select(e => e.FestivalGroup).Distinct().Count();
            }
        }

        // Gifts
        public ICollection<Copy> GiftsGiven { get; set; }
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

            EventsAttended = new List<MusicalEvent>();
            GiftsGiven = new List<Copy>();
        }
        #endregion
    }
}
