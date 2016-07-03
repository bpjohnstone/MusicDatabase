using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDatabase.ViewModel
{
    public class MusicalEntityPerformanceListing : MusicalEventBase
    {
        // Event Type
        //public EventType EventType { get; set; }

        public int Position { get; set; }
        public List<PerformerDetails> Performers { get; set; }
        public string PerformingAs { get; set; }
        public bool Attended { get; set; }
    }

    public class MusicalEntityHeadlinerListing : MusicalEntityPerformanceListing
    {

    }

    public class MusicalEntitySupportListing : MusicalEntityPerformanceListing
    {
        // Headliners
        public List<HeadlinerDetails> Headliners { get; set; }
    }
}
