using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDatabase.Model
{
    public class Element : Entity
    {
        #region Properties
        public int Count { get; set; }
        public virtual Format Format { get; set; }
        public int Position { get; set; }
        #endregion

        #region Constructors
        public Element()
            : this(0, null, 0)
        {

        }

        public Element(int count, Format format, int position)
        {
            Count = count;
            Format = format;
            Position = position;
        }
        #endregion
    }
}
