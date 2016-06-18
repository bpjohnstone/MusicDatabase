using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDatabase.Model
{
    public class Format : Entity
    {
        #region Properties
        public string Code { get; set; }
        public string Description { get; set; }
        #endregion

        #region Constructors
        public Format()
        {

        }

        public Format(string code)
            : this(code, code)
        {

        }

        public Format(string code, string description)
        {
            Code = code;
            Description = description;
        }
        #endregion
    }
}
