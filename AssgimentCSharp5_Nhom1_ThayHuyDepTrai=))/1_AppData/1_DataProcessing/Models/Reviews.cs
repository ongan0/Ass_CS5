using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_AppData._1_DataProcessing.Models
{
    public class Reviews
    {
        public Guid ID { get; set; }
        public Guid FoodID { get; set; }
        public Guid UserID { get; set; }
        public string Content { get; set; }
        public string Rating { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }

        public virtual Food Food { get; set; }
        public virtual User User { get; set; }
    }
}
