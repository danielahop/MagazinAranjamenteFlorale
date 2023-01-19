using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagazinAranjamenteFlorale.Models
{
    public class Product
    {
        public int ID { get; set; }


        [Required]
        public string Name { get; set; }



        [Range(1, 1000)]
        public int Price { get; set; }

        [Range(1, 100)]
        public int Stock { get; set; }

        
        public ICollection<OrderProduct>? OrderProducts { get; set; }
    }
}
