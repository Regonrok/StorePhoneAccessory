using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StorePhoneAccessory.Models
{
    public class Order
    {
        public int Id { get; set; }
        public decimal Cost { get; set; }
        public DateTime Date { get; set; }
        public bool IsBuy { get; set; }
        public int IdPerson { get; set; }

        public Person Person { get; set; }
        public DbSet<BasketField> BasketFields { get; set; }
    }
}
