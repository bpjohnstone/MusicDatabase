using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicDatabase.ViewModel
{
    public abstract class MusicalEntityBase
    {
        public Guid ID { get; set; }
        public string Name { get; set; }

        [Display(Name = "Sort Name")]
        public string SortName { get; set; }
    }

    public class MusicalEntityListing : MusicalEntityBase
    {
        // Used in MusicalEntities/Index
        [Display(Name = "Attended Performances")]
        public int Performances { get; set; }

        [Display(Name = "Owned Releases")]
        public int Releases { get; set; }
    }

    public class MusicalEntityDetails : MusicalEntityBase
    {
        // Used in MusicalEntities/Details
        public List<MusicalEventByMusicalEntity> Performances { get; set; }
        public Dictionary<int, ReleaseListing> Discography { get; set; }
    }
}
