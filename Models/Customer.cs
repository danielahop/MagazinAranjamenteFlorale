namespace MagazinAranjamenteFlorale.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }

        public string CustomerAddress { get; set; }

        public int CustomerPhoneNumber { get; set; }
        
        //public ICollection<Order>? Orders { get; set; }
    }
}
