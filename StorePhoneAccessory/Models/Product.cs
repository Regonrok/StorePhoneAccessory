using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorePhoneAccessory.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Company { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public int IdTypeProduct { get; set; }

        public TypeProduct TypeProduct { get; set; }
        public DbSet<BasketField> BasketFields { get; set; }
        public DbSet<Photo> Photos { get; set; }
    }
}
