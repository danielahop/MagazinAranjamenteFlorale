using System.ComponentModel.DataAnnotations;

namespace MagazinAranjamenteFlorale.Models
{
    public class Offer
    {
        public int ID { get; set; }

        [Required, StringLength(150, MinimumLength = 3)]
        public String Name { get; set; }

        [Range(1, 99)]
        public int Discount { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime EndDate { get; set; }

        public int ProductID { get; set; }

        [Range(1, 10)]
        public Product? Product { get; set; }

    }
}
