using System.Collections.Generic;

namespace MusicDatabase.Model
{
    public class Release : TaggedEntity
    {
        #region Properties
        public string Title { get; set; }
        public int Year { get; set; }

        public ReleaseType ReleaseType { get; set; }       // Album, EP, Single

        // Additional Descriptive Tags
        public bool IsCompilation { get { return HasTag(Model.Constants.RELEASE_TAG_COMPILATION); } }
        public bool IsLive { get { return HasTag(Model.Constants.RELEASE_TAG_LIVE); } }
        public bool IsRemixes { get { return HasTag(Model.Constants.RELEASE_TAG_REMIXES); } }
        public bool IsSoundtrack { get { return HasTag(Model.Constants.RELEASE_TAG_SOUNDTRACK); } }

        // Discography Entries (Whose discography does this appear in?)
        public virtual ICollection<DiscographyEntry> Discographies { get; set; }
        public string ReleasedBy { get; set; }

        // Copies
        public virtual ICollection<Copy> Copies { get; set; }
        #endregion

        #region Constructors
        public Release()
            : this("", 0)
        {

        }

        public Release(string title, int year)
        {
            Title = title;
            Year = year;

            Discographies = new List<DiscographyEntry>();
            Copies = new List<Copy>();
            Tags = new List<Tag>();
        }
        #endregion
    }
}
