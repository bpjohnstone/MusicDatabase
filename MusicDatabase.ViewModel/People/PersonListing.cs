﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDatabase.ViewModel
{
    public class PersonListing : PersonBase
    {
        [Display(Name="Events Attended")]
        public int EventsAttended { get; set; }

        [Display(Name="Gifts Given")]
        public int GiftsGiven { get; set; }
    }
}
