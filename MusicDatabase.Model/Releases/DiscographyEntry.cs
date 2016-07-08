namespace MusicDatabase.Model
{
    public class DiscographyEntry : Entity
    {
        #region Properties
        public int Position { get; set; }
        public virtual Release Release { get; set; }
        public virtual MusicalEntity MusicalEntity { get; set; }
        #endregion

        #region Constructors
        public DiscographyEntry()
        {

        }

        public DiscographyEntry(int position, Release release)
        {
            Position = position;
            Release = release;
        }
        #endregion
    }
}
