using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDatabase.ViewModel
{
    public abstract class MusicalEntityBase
    {
        public Guid ID { get; set; }
        public string Name { get; set; }

        [Display(Name="Sort Name")]
        public string SortName { get; set; }
    }
}
