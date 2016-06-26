using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDatabase.Model
{
    public class EventAttendee
    {
        #region Properties
        public Guid ID { get; set; }
        public int Position { get; set; }
        public virtual Person Person { get; set; }
        #endregion

        #region Constructors
        public EventAttendee()
            : this(0, null)
        {

        }

        public EventAttendee(int position, Person person)
        {
            ID = Guid.NewGuid();
            Position = position;
            Person = person;
        }
        #endregion
    }
}
