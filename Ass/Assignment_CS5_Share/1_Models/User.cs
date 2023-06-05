﻿namespace Assignment_CS5_Share._1_Models
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
        //public ICollection<Express_Delivery> Express_Delivery { get; set; }
        public ICollection<Reviews> Reviews { get; set; }
        public virtual Order Order { get; set; }
        public ICollection<Delivery_Address> Delivery_Addresses { get; set; }
    }
}
