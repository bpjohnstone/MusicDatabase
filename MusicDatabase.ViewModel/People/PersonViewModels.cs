﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicDatabase.ViewModel
{
    public class PersonBasic
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Psuedonym { get; set; }
    }

    public class PersonListing : PersonBasic
    {
        [Display(Name = "Events Attended")]
        public int EventsAttended { get; set; }

        [Display(Name = "Gifts Given")]
        public int GiftsGiven { get; set; }
    }

    public class PersonDetails : PersonBasic
    {
        public List<MusicalEventListing> EventsAttended { get; set; }
        public List<MusicalEventListing> UpcomingEvents { get; set; }

        // GiftsGiven
    }
}
