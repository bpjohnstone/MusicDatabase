using System;

namespace MusicDatabase.Model
{
    public class MultiDayFestival : MusicalEvent
    {
        #region Properties
        public virtual MultiDayFestivalGroup FestivalGroup { get; set; }
        public int Day { get; set; }
        #endregion

        #region Constructors
        public MultiDayFestival()
            : this(null, null)
        {

        }

        public MultiDayFestival(DateTime? eventDate, Location venue)
            : base(eventDate, venue)
        {

        }
        #endregion
    }
}
