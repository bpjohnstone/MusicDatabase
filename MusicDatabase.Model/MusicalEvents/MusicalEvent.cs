using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDatabase.Model
{
    public abstract class MusicalEvent : Entity
    {
        #region Properties
        public virtual Location Venue { get; set; }
        //public string 

        public DateTime? EventDate { get; set; }
        public string EventName { get; set; }
        public string Notes { get; set; }

        public virtual ICollection<Attendance> OtherAttendees { get; set; }
        #endregion

        #region Constructors
        public MusicalEvent()
            : this(null, "", null)
        {

        }

        public MusicalEvent(DateTime? eventDate, Location venue)
            : this(eventDate, "", venue)
        {

        }

        public MusicalEvent(DateTime? eventDate, string eventName, Location venue)
        {
            EventDate = eventDate;
            EventName = eventName;
            Venue = venue;

            OtherAttendees = new List<Attendance>();
        }
        #endregion
    }
}
