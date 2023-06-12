using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEN_NGAN_HANG
{
    public class Item
    {
        public string item { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }
        public int total
        {
            get { return quantity * price; }
        }
    }
}
