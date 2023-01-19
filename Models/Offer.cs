using System.ComponentModel.DataAnnotations;

namespace MagazinAranjamenteFlorale.Models
{
    public class Offer
    {
        public int ID { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage =
"Numele trebuie sa inceapa cu majuscula (ex. Promo)")]

        public string Name { get; set; }

        [Range(1, 99)]
        public int Discount { get; set; }

        [DataType(DataType.Date)]
      
        public DateTime EndDate { get; set; }

        public int ProductID { get; set; }

      
        public Product? Product { get; set; }

    }
}
