using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDatabase.Model
{
    public class Artist : MusicalEntity
    {
        #region Properties
        // Collection of Musical Groups the Artist has belonged to, and the timespans for each?
        #endregion

        #region Constructors
        public Artist()
            : this("", "")
        {

        }
        
        public Artist(string name)
            : this(name, name)
        {

        }

        public Artist(string name, string sortName)
            : base(name, sortName)
        {

        }
        #endregion
    }
}
