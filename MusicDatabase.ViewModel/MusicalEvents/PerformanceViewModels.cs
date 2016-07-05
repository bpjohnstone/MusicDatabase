using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDatabase.ViewModel
{
    public class PerformanceDetails
    {
        public int Position { get; set; }
        public List<PerformerDetails> Performers { get; set; }        
        public string PerformingAs { get; set; }
        public string Notes { get; set; }
        public bool Attended { get; set; }

        public PerformanceDetails()
        {
            Performers = new List<PerformerDetails>();
        }
    }
}
