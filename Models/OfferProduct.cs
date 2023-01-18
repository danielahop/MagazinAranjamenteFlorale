namespace MagazinAranjamenteFlorale.Models
{
    public class OfferProduct
    {
        public int ID { get; set; }

        public int OfferID { get; set; }

        public Offer Offer { get; set; }

        public int ProductID { get; set; }

        public Product? Product { get; set; }
    }
}
