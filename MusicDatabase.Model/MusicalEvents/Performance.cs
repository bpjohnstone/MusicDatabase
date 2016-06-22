using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDatabase.Model
{
    public class Performance
    {
        #region Properties
        public Guid ID { get; set; }
        public int? Position { get; set; }

        public virtual ICollection<Performer> Performers { get; set; }
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
            Performers = new List<Performer>();

            if (musicalEntity != null)
                Performers.Add(new Performer(Performers.Count() + 1, musicalEntity));

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

    public class Performer
    {
        #region Properties
        public Guid ID { get; set; }
        public int Position { get; set; }
        public MusicalEntity MusicalEntity { get; set; }
        #endregion

        #region Constructors
        public Performer()
            : this(1, null)
        {

        }

        public Performer(int position, MusicalEntity musicalEntity)
        {
            ID = Guid.NewGuid();
            Position = position;
            MusicalEntity = musicalEntity;
        }
        #endregion
    }
}