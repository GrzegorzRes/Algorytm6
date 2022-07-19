using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorytm6
{
    public class Travel
    {
        public int Price {  get; set; }
        public List<Place> Changes { get; set; }

        public Travel()
        {
            Changes = new List<Place>();
        }
        public Travel(Travel travel)
        {
            Changes = new List<Place>(travel.Changes);
            Price = travel.Price;
        }
    }
}
