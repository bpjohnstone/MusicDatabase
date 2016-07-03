using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDatabase.ViewModel
{
    public class MusicalEntityListing : MusicalEntityBase
    {
        [Display(Name="Attended Performances")]
        public int Performances { get; set; }

        [Display(Name="Owned Releases")]
        public int Releases { get; set; }
    }
}
