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

        // Event Group
        public string EventGroupName { get; set; }
        public Guid? EventGroupID { get; set; }

        // Venue
        public string VenueName { get; set; }
        public Guid VenueID { get; set; }
        public string VenueCity { get; set; }
    }
}
