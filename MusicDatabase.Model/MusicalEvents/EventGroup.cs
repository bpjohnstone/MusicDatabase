using System.Collections.Generic;

namespace MusicDatabase.Model
{
    // EventGroup are so that events can be grouped together, whether it be a festival series (Big Day Out, Splendour),
    // or just regular events, like Even Xmas shows or Don't Look Back shows.
    public class EventGroup : AbstractGroup
    {
        #region Properties
        public ICollection<MusicalEvent> MusicalEvents { get; set; }
        #endregion

        #region Constructors
        public EventGroup()
            : this("", "")
        {

        }

        public EventGroup(string name, string notes)
            : base(name, notes)
        {
            MusicalEvents = new List<MusicalEvent>();
        }
        #endregion
    }

    // Used to group MultiDayFestival Days together, e.g. Splendour 2011, Splendour 2010 and Apollo Bay Music Festival
    public class MultiDayFestivalGroup : AbstractGroup
    {
        #region Properties
        public ICollection<MultiDayFestival> Days { get; set; }
        #endregion

        #region Constructors
        public MultiDayFestivalGroup()
            : this("", "")
        {

        }

        public MultiDayFestivalGroup(string name, string notes)
            : base(name, notes)
        {
            Days = new List<MultiDayFestival>();
        }
        #endregion
    }
}
