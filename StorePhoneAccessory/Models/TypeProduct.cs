using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorePhoneAccessory.Models
{
    public class TypeProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<SubtypeProduct> SubtypeProducts { get; set; }
    }
}
