using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicDatabase.Model
{
    // MusicalEvents have a lineup, which is a collection of Performances.

    // The basic Performance object contains all of the details involved with Performances, but is also extended
    // further into two additional types, Headliner and Support, which indicate a MusicalEntity's status at the a
    // Concert. Performances are ordered via the Position property, with the final performer of the night at 
    // listed first, and working backwards from there.

    // A MusicalEvent can have multiple Headliners (For example, the Queens of the Stone Age and Nine Inch Nails
    // co-headlining shows together, and playing their own individual sets).

    // There is currently no checking enforced on this, but as a standard, Concerts have Headliners and Supports, 
    // while Festivals have Headliners and Performances.

    // The PerformingAs property covers when MusicalEntities will go under different names
    // For example, Devin Townsend performing as "Devin Townsend Project" or Something for Kate doing secret shows
    // under alternate names, like "George Kaplan and the Editors" or "Jerry and the Manmade Sharks".

    // A Performance also has collection of Performers, as a Performance can have multiple MusicalEntities involved: 
    // For example, Suzannah Espie and Ian Collard, two individual musicians performing an acoustic set together. 
    // Performers are also numbered (via the Position property) in the order they should be displayed

    // This can eventually go further, with fully-fledged recording and touring collaborations between MusicalEntities
    // For example: Miley Cyrus and Her Dead Petz (Miley Cyrus and The Flaming Lips) or Neil Young + The Promise of
    // the Real. These become standalone MusicalEntities, though at some point, these will be further wired up
    // to include references back to the contributing Entities, with the goal of including the collaborative 
    // Releases and Performances in each's own Discography and Performance lists. (Marked appropriately, of course).

    // Finally, the Attended property (defaulting to true) indicates whether this performance was actually attended
    // There have been times where Headliners have been missed (like missing Motor Ace's final show because of 
    // needing to catch a train back to Geelong), or the bazillion Support acts that I've skipped over the years. 
    // (The latter, however, generally don't get included in the Lineup collection)

    public class Performance
    {
        #region Properties
        public Guid ID { get; set; }
        public int? Position { get; set; }

        public ICollection<Performer> Performers { get; set; }
        public string PerformingAs { get; set; }

        public virtual MusicalEvent Event { get; set; }
        public string Notes { get; set; }

        public bool Attended { get; set; }
        #endregion

        #region Constructors
        public Performance()
            : this(0, null, null)
        {

        }

        public Performance(int position, MusicalEvent musicalEvent, MusicalEntity musicalEntity)
        {
            ID = Guid.NewGuid();
            Position = position;
            Performers = new List<Performer>();

            if (musicalEntity != null)
                Performers.Add(new Performer(Performers.Count() + 1, musicalEntity));

            Event = musicalEvent;
            Attended = true;        // By default, it's assumed that the performance was seen
        }
        #endregion
    }

    public class Headliner : Performance
    {
        public Headliner()
        {

        }

        public Headliner(int position, MusicalEvent musicalEvent, MusicalEntity musicalEntity)
            : base(position, musicalEvent, musicalEntity)
        {

        }
    }

    public class Support : Performance
    {
        public Support()
        {

        }

        public Support(int position, MusicalEvent musicalEvent, MusicalEntity musicalEntity)
            : base(position, musicalEvent, musicalEntity)
        {

        }
    }

    public class Performer
    {
        #region Properties
        public Guid ID { get; set; }
        public int Position { get; set; }
        public virtual MusicalEntity MusicalEntity { get; set; }
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