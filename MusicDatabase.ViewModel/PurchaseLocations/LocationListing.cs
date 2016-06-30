using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDatabase.ViewModel
{
    public class LocationListing : LocationBase
    {
        [Display(Name="Musical Events")]
        public int MusicalEvents { get; set; }
        public int Purchases { get; set; }
    }
}
