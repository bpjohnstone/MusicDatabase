using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDatabase.Model
{
    public class MusicalGroup : MusicalEntity
    {
        #region Properties
        // Collection of the Artists that have belonged to the Group, and timespans?
        #endregion

        #region Constructors
        public MusicalGroup()
            : this("", "")
        {

        }

        public MusicalGroup(string name)
            : this(name,name)
        {

        }

        public MusicalGroup(string name, string sortName)
            : base(name, sortName)
        {

        }
        #endregion
    }
}
