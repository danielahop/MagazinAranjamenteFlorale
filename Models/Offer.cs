using System.ComponentModel.DataAnnotations;

namespace MagazinAranjamenteFlorale.Models
{
    public class Offer
    {
        public int ID { get; set; }

        public String Name { get; set; }

        public int Discount { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public int ProductID { get; set; }

        public Product? Product { get; set; }

    }
}
