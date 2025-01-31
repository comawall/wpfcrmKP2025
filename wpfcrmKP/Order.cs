using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfcrmKP
{
    public class Order
    {
        public string OrderNumber { get; set; }
        public string ItemCount { get; set; }
        public string Time { get; set; }
        public string DishCode { get; set; }
        public string PickupMethod { get; set; }
        public decimal OrderCost { get; set; } 
    }

}
