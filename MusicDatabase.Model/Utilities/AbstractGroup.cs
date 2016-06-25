using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDatabase.Model
{
    public abstract class AbstractGroup : Entity
    {
        #region Properties
        public string Name { get; set; }
        public string Notes { get; set; }
        #endregion

        #region Constructors
        public AbstractGroup()
            : this("", "")
        {

        }

        public AbstractGroup(string name, string notes)
        {
            Name = name;
            Notes = notes;
        }
        #endregion
    }
}
