using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorePhoneAccessory.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public byte[] Img { get; set; }
        public int IdProduct { get; set; }

        public Product Product { get; set; }
    }
}
