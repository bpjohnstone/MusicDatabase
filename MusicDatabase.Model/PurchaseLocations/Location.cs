using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicDatabase.Model
{
    public class Location : Entity
    {
        #region Properties
        public string Name { get; set; }
        public virtual LocationGroup LocationGroup { get; set; }

        public string FullName
        {
            get
            {
                if (LocationGroup != null)
                    return string.Format("{0} - {1}", LocationGroup.Name, Name);
                else
                    return Name;
            }
        }

        public virtual ICollection<AlternateLocationName> OtherNames { get; set; }

        public string Address { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }

        public string Notes { get; set; }

        public ICollection<MusicalEvent> MusicalEvents { get; set; }    // Collection of Concerts / Festivals
        public int TotalEvents
        {
            get
            {
                return MusicalEvents.Count(e => e is SingleDayEvent) + MusicalEvents.OfType<MultiDayFestival>().Select(e => e.FestivalGroup).Distinct().Count();
            }
        }

        public ICollection<Copy> Purchases { get; set; }                // Collection of Purchases
        
        public bool IsClosed { get; set; }
        #endregion

        #region Constructors
        public Location()
            : this("")
        {

        }

        public Location(string name)
            : this(name, "", "", "")
        {

        }

        public Location(string name, string city, string state, string country)
        {
            Name = name;
            City = city;
            State = state;
            Country = country;

            MusicalEvents = new List<MusicalEvent>();
            Purchases = new List<Copy>();
            OtherNames = new List<AlternateLocationName>();
        }
        #endregion
    }

    public class AlternateLocationName
    {
        #region Properties
        public Guid ID { get; set; }
        public int Position { get; set; }
        public string Name { get; set; }
        #endregion

        #region Constructors
        public AlternateLocationName()
            : this(0, "")
        {

        }

        public AlternateLocationName(int position, string name)
        {
            ID = Guid.NewGuid();
            Position = position;
            Name = name;
        }
        #endregion
    }

    public class LocationGroup : AbstractGroup
    {
        #region Properties
        public ICollection<Location> Locations { get; set; }

        // A group of locations can have a website (i.e. JB Hifi or Red Eye Records)
        public virtual Website Website { get; set; }
        #endregion

        #region Constructors
        public LocationGroup()
            : this("", "")
        {

        }

        public LocationGroup(string name, string notes)
            : base(name, notes)
        {
            Locations = new List<Location>();
        }
        #endregion
    }
}
