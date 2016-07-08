using System;
using System.Collections.Generic;

namespace MusicDatabase.ViewModel
{
    public class EventGroupDetails
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }

        public List<MusicalEventListing> MusicalEvents { get; set; }
    }

    // Is it really necessary to have an event group listing?
    // Probably *shrugs*
}
