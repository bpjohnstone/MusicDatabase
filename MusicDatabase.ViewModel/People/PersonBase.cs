using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDatabase.ViewModel
{
    public abstract class PersonBase
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Psuedonym { get; set; }
    }
}
