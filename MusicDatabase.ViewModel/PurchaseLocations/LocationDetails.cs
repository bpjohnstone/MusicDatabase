using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDatabase.ViewModel
{
    public class LocationDetails : LocationBase
    {
        public string Address { get; set; }
        public string Suburb { get; set; }
        public string Postcode { get; set; }

        public string Notes { get; set; }

        public Dictionary<int, string> OtherNames { get; set; }
        public List<MusicalEventListing> MusicalEvents { get; set; }
        // Purchases

        public LocationDetails()
        {
            OtherNames = new Dictionary<int, string>();
        }
    }
}
