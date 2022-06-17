using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Classes
{
    public class FinalOrder
    {
        public string Title { get; set; }
        public string firstName { get; set; }
        public int BookID { get; set; }
        public string Email { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
