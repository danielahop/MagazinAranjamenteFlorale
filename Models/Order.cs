using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace MagazinAranjamenteFlorale.Models
{
    public class Order
    {
        public int ID { get; set; }


        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }

        public int CustomerID { get; set; }

        public Customer? Customer { get; set; }

        public ICollection<OrderProduct>? OrderProducts { get; set; }
    }
}
