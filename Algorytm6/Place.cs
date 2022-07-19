using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorytm6
{
    public class Place
    {
        public string NamePlace { get; set; }
        public Dictionary<Place, int> Connections { get; set; }

        public Place()
        {
            Connections = new Dictionary<Place, int>();
        }
    }
}
