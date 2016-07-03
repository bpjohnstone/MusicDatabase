using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDatabase.ViewModel
{
    public class MusicalEntityDetails : MusicalEntityBase
    {
        public List<MusicalEntityPerformanceListing> Performances { get; set; }
    }
}
