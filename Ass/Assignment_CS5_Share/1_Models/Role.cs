namespace Assignment_CS5_Share._1_Models
{
    public class Role
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
