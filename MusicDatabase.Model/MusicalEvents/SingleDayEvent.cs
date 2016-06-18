using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDatabase.Model
{
    public abstract class SingleDayEvent : MusicalEvent
    {
        #region Properties
        public virtual ICollection<Performance> Lineup { get; set; }
        #endregion

        #region Constructors
        public SingleDayEvent()
            : this(null, "", null)
        {

        }

        public SingleDayEvent(DateTime? eventDate, string eventName, Location venue)
            : base(eventDate, eventName, venue)
        {
            Lineup = new List<Performance>();
        }
        #endregion
    }

    public class Concert : SingleDayEvent
    {
        public Concert()
            : this(null, "", null)
        {

        }

        public Concert(DateTime? eventDate, Location venue)
            : this(eventDate, "", venue)
        {

        }

        public Concert(DateTime? eventDate, string eventName, Location venue)
            : base(eventDate, eventName, venue)
        {

        }

    }

    public class Festival : SingleDayEvent
    {
        public Festival()
            : this(null, "", null)
        {

        }

        public Festival(DateTime? eventDate, Location venue)
            : this(eventDate, "", venue)
        {

        }

        public Festival(DateTime? eventDate, string eventName, Location venue)
            : base(eventDate, eventName, venue)
        {

        }
    }
}
