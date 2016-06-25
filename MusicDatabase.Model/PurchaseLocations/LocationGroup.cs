using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDatabase.Model
{
    public class LocationGroup : AbstractGroup
    {
        #region Properties
        public virtual ICollection<Location> Locations { get; set; }
        #endregion

        #region Constructors
        public LocationGroup()
            :this("", "")
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
