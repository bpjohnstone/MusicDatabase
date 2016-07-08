using System;

namespace MusicDatabase.ViewModel
{
    #region Base Classes
    public class WebsiteBase
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }

    public class WebsiteListing : WebsiteBase
    {
        public int Purchases { get; set; }
    }

    #endregion

}
