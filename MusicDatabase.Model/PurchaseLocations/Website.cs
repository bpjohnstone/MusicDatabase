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
        public virtual WebsiteGroup WebsiteGroup { get; set; }

        public string SearchName
        {
            get
            {
                if (WebsiteGroup != null)
                    return string.Format("{0} - {1}", WebsiteGroup.Name, Name);
                else
                    return Name;
            }
        }
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

    public class WebsiteGroup : AbstractGroup
    {
        #region Properties
        public virtual ICollection<Website> Websites { get; set; }
        #endregion

        #region Constructors
        public WebsiteGroup()
            : this("", "")
        {

        }

        public WebsiteGroup(string name, string notes)
            : base(name, notes)
        {
            Websites = new List<Website>();
        }
        #endregion
    }
}
