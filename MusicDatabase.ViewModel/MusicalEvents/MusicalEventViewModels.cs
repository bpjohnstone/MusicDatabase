using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDatabase.ViewModel
{
    public abstract class MusicalEventBase
    {
        public Guid ID { get; set; }
        public DateTime EventDate { get; set; }

        public string EventName { get; set; }

        public Guid? EventGroupID { get; set; }
        public string EventGroupName { get; set; }

        public EventType EventType { get; set; }
    }

    public class MusicalEventByLocation : MusicalEventBase
    {
        // Used in Locations/Details view
        // Doesn't need venue details, so derives from the base
        public List<PerformanceDetails> Headliners { get; set; }
    }

    public abstract class MusicalEventSimple : MusicalEventBase
    {
        // Includes Venue Details
        public Guid? VenueID { get; set; }
        public string VenueName { get; set; }
        public string VenueCity { get; set; }
    }

    public class MusicalEventListing : MusicalEventSimple
    {
        // Used in MusicalEvents/Index view
        public List<PerformanceDetails> Headliners { get; set; }
    }

    public class MusicalEventDetails : MusicalEventSimple
    {
        // Used in MusicalEvents/Details view
        public string Notes { get; set; }

        public List<PerformanceDetails> Lineup { get; set; }
        public Dictionary<int, PersonBasic> OtherAttendees { get; set; }
    }

    public class MusicalEventByMusicalEntity : MusicalEventSimple
    {
        // Used in MusicalEntities/Details view
    }
}
