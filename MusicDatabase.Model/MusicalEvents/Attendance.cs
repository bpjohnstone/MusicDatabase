using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDatabase.Model
{
    public class Attendance
    {
        public Guid ID { get; set; }
        public virtual Person Attendee { get; set; }
        public virtual MusicalEvent MusicalEvent { get; set; }
        public string Notes { get; set; }

        public Attendance()
            : this(null, null)
        {

        }

        public Attendance(Person attendee, MusicalEvent musicalEvent)
        {
            ID = System.Guid.NewGuid();
            Attendee = attendee;
            MusicalEvent = musicalEvent;
        }
    }
}
