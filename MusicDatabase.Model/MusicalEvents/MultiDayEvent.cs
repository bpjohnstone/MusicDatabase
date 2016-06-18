using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDatabase.Model
{
    public abstract class MultiDayEvent : MusicalEvent
    {
        // Collection of Days
        public virtual ICollection<Day> Days { get; set; }

        public MultiDayEvent()
            : this(null, null)
        {

        }

        public MultiDayEvent(DateTime? startDate, Location venue)
            : base(startDate, venue)
        {
            Days = new List<Day>();
        }
    }

    public class Day
    {
        public Guid ID { get; set; }
        public DateTime? Date { get; set; }
        public virtual ICollection<Performance> Lineup { get; set; }

        public Day()
            : this(null)
        {

        }

        public Day(DateTime? date)
        {
            ID = Guid.NewGuid();
            Date = date;
            Lineup = new List<Performance>();
        }
    }

    public class MultiDayFestival : MultiDayEvent
    {
        public MultiDayFestival()
            : this(null, null)
        {

        }

        public MultiDayFestival(DateTime? eventDate, Location venue)
            : base(eventDate, venue)
        {

        }
    }
}
