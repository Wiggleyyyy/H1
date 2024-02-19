using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection
{
    public class OrderData
    {
        public int id { get; set; }
        public int customerId { get; set; }
        public int itemId { get; set; }
        public string orderDate { get; set; }
        public int forwarderId { get; set; }
    }
}
