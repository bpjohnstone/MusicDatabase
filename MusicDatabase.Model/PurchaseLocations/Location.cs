﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDatabase.Model
{
    public class Location : Entity
    {
        #region Properties
        public string Name { get; set; }

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

        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }

        // Location Group
        public virtual LocationGroup LocationGroup { get; set; }

        // Collection of Concerts / Festivals
        public virtual ICollection<MusicalEvent> MusicalEvents { get; set; }

        // Other Names
        public virtual ICollection<AlternateLocationName> OtherNames { get; set; }

        public string Notes { get; set; }

        public bool Closed { get; set; }
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
}
