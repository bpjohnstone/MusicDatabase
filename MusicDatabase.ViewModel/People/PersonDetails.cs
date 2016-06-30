using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDatabase.ViewModel
{
    public class PersonDetails
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Psuedonym { get; set; }

        public List<MusicalEventListing> EventsAttended { get; set; }

        public PersonDetails()
        {
            EventsAttended = new List<MusicalEventListing>();
        }
    }
}
