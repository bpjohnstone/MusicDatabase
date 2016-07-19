using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MusicDatabase.ViewModel
{
    #region Base Classes
    public abstract class LocationBase
    {
        public Guid ID { get; set; }

        public string Name { get; set; }
        public string LocationGroupName { get; set; }
        public Guid? LocationGroupID { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        [Display(Name = "Closed")]
        public bool IsClosed { get; set; }
    }

    public class LocationListing : LocationBase
    {
        // Used in Locations/Index view
        // Used in any "Filtered" view (e.g. City, State, Country)
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
        public List<MusicalEventByLocation> UpcomingMusicalEvents { get; set; }

        //public List<CopyDetails> Purchases { get; set; }

        public LocationDetails()
        {
            OtherNames = new Dictionary<int, string>();
        }
    }
    #endregion

    #region ViewModels
    public class LocationListingCollection
    {
        public List<LocationListing> Locations { get; set; }

        public int TotalMusicalEvents
        {
            get { return Locations.Sum(l => l.MusicalEvents); }
        }

        public int TotalPurchases
        {
            get { return Locations.Sum(l => l.Purchases); }
        }

        public LocationListingCollection()
        {
            Locations = new List<LocationListing>();
        }
    }

    public class FilteredLocationListingCollection : LocationListingCollection
    {
        public string Filter { get; set; }
        public FilterLocationBy FilterType { get; set; }
    }
    
    public class LocationGroupDetails : LocationListingCollection
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }

        public Guid? WebsiteID { get; set; }
    }
    #endregion
}
