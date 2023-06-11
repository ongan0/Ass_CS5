using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_AppData._1_DataProcessing.Models
{
    public class Combo
    {
        public Guid ID { get; set; }
        public Guid FoodID { get; set; }
        public string ComboName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }

        public ICollection<Coupons> Coupons { get; set; }
        public ICollection<Food> Food { get; set; }
    }
}
