using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDatabase.Model
{
    public abstract class Performance
    {
        #region Properties
        public Guid ID { get; set; }
        public int? Position { get; set; }
        public virtual MusicalEntity MusicalEntity { get; set; }
        public string PerformingAs { get; set; }
        public virtual MusicalEvent Event { get; set; }
        public string Notes { get; set; }
        #endregion

        #region Constructors
        public Performance()
            : this(null, null, null)
        {

        }

        public Performance(int? position, MusicalEvent musicalEvent, MusicalEntity musicalEntity)
        {
            ID = Guid.NewGuid();
            Position = position;
            MusicalEntity = musicalEntity;
            Event = musicalEvent;
        }
        #endregion
    }

    public class Headliner : Performance
    {
        public Headliner()
        {

        }

        public Headliner(int? position, MusicalEvent musicalEvent, MusicalEntity musicalEntity)
            : base(position, musicalEvent, musicalEntity)
        {

        }
    }

    public class Support : Performance
    {
        public Support()
        {

        }

        public Support(int? position, MusicalEvent musicalEvent, MusicalEntity musicalEntity)
            : base(position, musicalEvent, musicalEntity)
        {

        }
    }

    public class Performer : Performance
    {
        public Performer()
        {

        }

        public Performer(MusicalEvent musicalEvent, MusicalEntity musicalEntity)
            : base(null, musicalEvent, musicalEntity)
        {

        }
    }
}