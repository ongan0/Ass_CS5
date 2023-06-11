using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_AppData._1_DataProcessing.Models
{
    public class OrderDetail
    {
        public Guid ID { get; set; }
        public Guid OrderID { get; set; }
        public Guid FoodID { get; set; }
        public int Quantity { get; set; }

        public ICollection<Food> Food { get; set; }
        public virtual Ordel Order { get; set; }
    }
}
