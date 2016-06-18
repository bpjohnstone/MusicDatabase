using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDatabase.Model
{
    public class Website : Entity
    {
        #region Properties
        public string Name { get; set; }
        public string Address { get; set; }
        #endregion

        #region Constructors
        public Website()
            : base()
        {

        }

        public Website(string name)
            : this(name, "")
        {

        }

        public Website(string name, string address)
            : base()
        {
            Name = name;
            Address = address;
        }
        #endregion
    }
}
