using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDatabase.ViewModel
{
    public class PerformanceListing
    {
        public int Position { get; set; }
        public List<PerformerDetails> Performers { get; set; }        
        public string PerformingAs { get; set; }

        public PerformanceListing()
        {
            Performers = new List<PerformerDetails>();
        }
    }
}
