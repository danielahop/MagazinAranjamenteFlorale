﻿using System.ComponentModel.DataAnnotations;

namespace MagazinAranjamenteFlorale.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage =
"Numele trebuie sa inceapa cu majuscula (ex. Daniela sau Felicia Daniela)")]

        public string CustomerName { get; set; }

        [Required]
        public string CustomerAddress { get; set; }

        [Required]
        public int CustomerPhoneNumber { get; set; }
        
        //public ICollection<Order>? Orders { get; set; }
    }
}
