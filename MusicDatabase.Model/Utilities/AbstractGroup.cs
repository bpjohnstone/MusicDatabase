namespace MusicDatabase.Model
{
    public abstract class AbstractGroup : Entity
    {
        #region Properties
        public string Name { get; set; }
        public string Notes { get; set; }
        #endregion

        #region Constructors
        public AbstractGroup()
            : this("", "")
        {

        }

        public AbstractGroup(string name, string notes)
        {
            Name = name;
            Notes = notes;
        }
        #endregion
    }
}
