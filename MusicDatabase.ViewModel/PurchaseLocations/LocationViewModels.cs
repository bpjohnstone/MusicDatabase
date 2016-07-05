using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDatabase.ViewModel
{
    public abstract class LocationBase
    {
        public Guid ID { get; set; }

        public string Name { get; set; }
        public string LocationGroupName { get; set; }
        public Guid? LocationGroupID { get; set; }
        public string SortName { get; set; }

        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        [Display(Name = "Closed")]
        public bool IsClosed { get; set; }
    }

    public class LocationListing : LocationBase
    {
        // Used in Locations/Index view
        [Display(Name="Musical Events")]
        public int MusicalEvents { get; set; }
        public int Purchases { get; set; }
    }

    public class LocationDetails : LocationBase
    {
        // Used in Locations/Details view
        public string Address { get; set; }
        public string Suburb { get; set; }
        public string Postcode { get; set; }

        public string Notes { get; set; }

        [Display(Name="Other Names")]
        public Dictionary<int, string> OtherNames { get; set; }
        public List<MusicalEventByLocation> MusicalEvents { get; set; }
        //public List<CopyDetails> Purchases { get; set; }

        public LocationDetails()
        {
            OtherNames = new Dictionary<int, string>();
        }
    }
}
