using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDatabase.ViewModel
{
    public abstract class LocationBase
    {
        public Guid ID { get; set; }

        public string Name { get; set; }
        public string LocationGroup { get; set; }
        public Guid? LocationGroupID { get; set; }
        public string SortName { get; set; }

        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        [Display(Name = "Closed")]
        public bool IsClosed { get; set; }
    }
}
