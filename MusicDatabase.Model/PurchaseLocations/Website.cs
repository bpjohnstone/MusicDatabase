using System.Collections.Generic;

namespace MusicDatabase.Model
{
    public class Website : Entity
    {
        #region Properties
        public string Name { get; set; }
        public string Address { get; set; }
        public WebsiteGroup WebsiteGroup { get; set; }
        public string Notes { get; set; }

        public string SortName
        {
            get
            {
                if (WebsiteGroup != null)
                    return string.Format("{0} - {1}", WebsiteGroup.Name, Name);
                else
                    return Name;
            }
        }

        public virtual ICollection<Copy> Purchases { get; set; }
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
            Purchases = new List<Copy>();
        }
        #endregion
    }

    public class WebsiteGroup : AbstractGroup
    {
        #region Properties
        public ICollection<Website> Websites { get; set; }
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
