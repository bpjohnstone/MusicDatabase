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
        
        public string EventGroup { get; set; }
        public Guid EventGroupID { get; set; }

        public string EventName { get; set; }

        public string VenueName { get; set; }
        public Guid VenueID { get; set; }

        public List<PerformanceListing> Headliners { get; set; }

        public MusicalEventListing()
        {
            Headliners = new List<PerformanceListing>();
        }
    }
}
