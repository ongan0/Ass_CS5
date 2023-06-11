using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_AppData._1_DataProcessing.Models
{
    public class Category
    {
        public Guid ID { get; set; }
        public Guid FoodID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Food> Food { get; set; }
        public ICollection<Combo> combos { get; set; }
    }
}
