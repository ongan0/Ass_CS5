using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_AppData._1_DataProcessing.Models
{
    public class User
    {
        public Guid ID { get; set; }
        public Guid IDRole { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Status { get; set; }

        public virtual Role Role { get; set; }
        public ICollection<Bill> Bills { get; set; }
        public ICollection<Reviews> Reviews { get; set; }
        public virtual ICollection<Ordel> Orders { get; set; }
        //public ICollection<Delivery_Address> Delivery_Addresses { get; set; }
    }
}
