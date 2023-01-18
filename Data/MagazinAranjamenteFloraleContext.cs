using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MagazinAranjamenteFlorale.Models;

namespace MagazinAranjamenteFlorale.Data
{
    public class MagazinAranjamenteFloraleContext : DbContext
    {
        public MagazinAranjamenteFloraleContext (DbContextOptions<MagazinAranjamenteFloraleContext> options)
            : base(options)
        {
        }

        public DbSet<MagazinAranjamenteFlorale.Models.Order> Order { get; set; } = default!;

        public DbSet<MagazinAranjamenteFlorale.Models.Customer> Customer { get; set; }

        public DbSet<MagazinAranjamenteFlorale.Models.Product> Product { get; set; }
    }
}
