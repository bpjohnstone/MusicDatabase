using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDatabase.ViewModel
{
    public class MusicalEventListing
    {
        public Guid ID { get; set; }
        public DateTime EventDate { get; set; }
        
        public string EventGroupName { get; set; }
        public Guid EventGroupID { get; set; }

        public string EventName { get; set; }

        public string VenueName { get; set; }
        public Guid VenueID { get; set; }
        public string VenueCity { get; set; }

        public List<HeadlinerDetails> Headliners { get; set; }

        public MusicalEventListing()
        {
            Headliners = new List<HeadlinerDetails>();
        }
    }

    public abstract class SingleDayEventListing : MusicalEventListing
    {
    }

    public class ConcertListing : SingleDayEventListing
    {

    }

    public class FestivalListing : SingleDayEventListing
    {

    }

    public class MultiDayFestivalListing : MusicalEventListing
    {

    }
}
