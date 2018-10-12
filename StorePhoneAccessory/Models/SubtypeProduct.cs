using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorePhoneAccessory.Models
{
    public class SubtypeProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdTypeProduct { get; set; }

        public TypeProduct TypeProduct { get; set; }
    }
}
