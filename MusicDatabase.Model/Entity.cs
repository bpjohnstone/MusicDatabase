using System;

namespace MusicDatabase.Model
{
    public class Entity
    {
        #region Properties
        public Guid ID { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool IsActive { get; set; }
        #endregion

        #region Constructors
        public Entity()
        {
            ID = System.Guid.NewGuid();
            DateCreated = DateTime.Now;
            LastUpdated = DateTime.Now;
            IsActive = true;
        }
        #endregion
    }
}
