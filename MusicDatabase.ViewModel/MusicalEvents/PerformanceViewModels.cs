using System.Collections.Generic;
using System.Text;

namespace MusicDatabase.ViewModel
{
    public class PerformanceDetails
    {
        public int Position { get; set; }
        public List<PerformerDetails> Performers { get; set; }
        public PerformanceType PerformanceType { get; set; }    
        public string PerformingAs { get; set; }
        public string Notes { get; set; }
        public bool Attended { get; set; }

        public string PerformanceDescription
        {
            get
            {
                var output = new StringBuilder();
                var performerCount = Performers.Count;

                if ((!string.IsNullOrWhiteSpace(PerformingAs)) && (performerCount == 1))
                {
                    output.Append(PerformingAs);

                }
                else
                {
                    var performerIndex = 1;
                    foreach (var performer in Performers)
                    {
                        if (performerIndex > 1)
                        {
                            if (performerIndex == 1)
                                output.Append(" with ");
                            else if (performerIndex == performerCount)
                                output.Append(" and ");
                            else
                                output.Append(", ");
                        }

                        output.Append(performer.MusicalEntityName);
                        performerIndex++;
                    }
                }
                
                return output.ToString();
            }
        }


        public PerformanceDetails()
        {
            Performers = new List<PerformerDetails>();
        }
    }
}
