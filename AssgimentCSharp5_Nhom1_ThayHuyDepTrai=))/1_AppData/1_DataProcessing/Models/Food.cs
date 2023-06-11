using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_AppData._1_DataProcessing.Models
{
    public class Food
    {
        public Guid ID { get; set; }
        public string FoodName { get; set; }
        public decimal Price { get; set; }
        public string Images { get; set; }
        public string Description { get; set; }

        public ICollection<Combo> Combos { get; set; }
        public ICollection<Category> Categorys { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public ICollection<BillDetail> BillDetails { get; set; }
        public ICollection<Coupons> Coupons { get; set; }
        public ICollection<Reviews> Reviews { get; set; }
    }
}
