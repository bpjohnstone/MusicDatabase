using System;

namespace MusicDatabase.Model
{
    public abstract class SingleDayEvent : MusicalEvent
    { 
        public SingleDayEvent(DateTime? eventDate, Location venue)
            : base(eventDate, venue)
        {

        }
    }

    public class Concert : SingleDayEvent
    {
        public bool IsSecret { get; set; }  // Was the Concert a secret show?

        public Concert()
            : this(null, null)
        {

        }

        public Concert(DateTime? eventDate, Location venue)
            : base(eventDate, venue)
        {
            IsSecret = false;
        }
    }

    public class Festival : SingleDayEvent
    {
        public Festival()
            : this(null, null)
        {

        }

        public Festival(DateTime? eventDate, Location venue)
            : base(eventDate, venue)
        {

        }
    }

}
