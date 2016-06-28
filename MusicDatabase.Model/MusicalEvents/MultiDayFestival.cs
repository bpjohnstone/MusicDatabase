using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDatabase.Model
{
    public class MultiDayFestival : MusicalEvent
    {
        #region Properties
        public virtual MultiDayFestivalGroup FestivalGroup { get; set; }
        #endregion

        #region Constructors
        public MultiDayFestival()
            : this(null, null)
        {

        }

        public MultiDayFestival(DateTime? eventDate, Location venue)
            : base(eventDate, venue)
        {

        }
        #endregion
    }
}
