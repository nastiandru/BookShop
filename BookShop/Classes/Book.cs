using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Classes
{
    public class Book
    {
        public int Id { get; set; }
        public string title { get; set; }
        public int timePeriod { get; set; }
        public string author { get; set; }
        public string edition { get; set; }
        public string Summary { get; set; }
    }
}
