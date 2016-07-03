using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDatabase.ViewModel
{
    public class MusicalEventListing : MusicalEventBase
    {
        // Headliners
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
