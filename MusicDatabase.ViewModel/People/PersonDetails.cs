using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDatabase.ViewModel
{
    public class PersonDetails : PersonBase
    {
        public List<MusicalEventListing> EventsAttended { get; set; }

        public PersonDetails()
        {
            EventsAttended = new List<MusicalEventListing>();
        }
    }
}
