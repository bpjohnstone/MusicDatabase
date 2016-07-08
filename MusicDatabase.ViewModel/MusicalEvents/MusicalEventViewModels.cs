using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicDatabase.ViewModel
{
    public abstract class MusicalEventBase
    {
        public Guid ID { get; set; }
        public DateTime EventDate { get; set; }

        public string EventName { get; set; }

        public Guid? EventGroupID { get; set; }
        public string EventGroupName { get; set; }

        public bool IsSecret { get; set; }
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
        public string EventTitle
        {
            get
            {
                string title = string.Empty;

                if (!string.IsNullOrWhiteSpace(EventName))
                { 
                    title = EventName;
                }
                else if (!string.IsNullOrWhiteSpace(EventGroupName))
                { 
                    title = EventGroupName;
                }
                else
                {
                    var output = new StringBuilder();
                    var headlinerCount = Lineup.Where(p => p.PerformanceType == PerformanceType.Headliner).Count();
                    var headlinerIndex = 1;

                    foreach (var performance in Lineup.Where(p => p.PerformanceType == PerformanceType.Headliner).OrderBy(p => p.Position))
                    {
                        if(headlinerIndex > 1)
                        {
                            if (headlinerIndex == headlinerCount)
                                output.Append(" and ");
                            else
                                output.Append(", ");
                        }

                        output.Append(performance.PerformanceDescription);
                        headlinerIndex++;
                    }

                    title = output.ToString();
                }

                return title;
            }
        }

        public string Notes { get; set; }

        public List<PerformanceDetails> Lineup { get; set; }
        public Dictionary<int, PersonBasic> OtherAttendees { get; set; }
    }

    // Will need to add an extended class to handle MultiDayFestivals

    public class MusicalEventByMusicalEntity : MusicalEventSimple
    {
        // Used in MusicalEntities/Details view
    }
}
