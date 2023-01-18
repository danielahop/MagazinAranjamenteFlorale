namespace MagazinAranjamenteFlorale.Models
{
    public class Product
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public int Stock { get; set; }

        public ICollection<OrderProduct>? OrderProducts { get; set; }
    }
}
